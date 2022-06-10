import React, {useState, useMemo, useEffect} from 'react';
import {
  View,
  Image,
  StyleSheet,
  TouchableOpacity,
  ScrollView,
  Dimensions,
  Alert,
} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import {Modal, Portal, Button, Provider, Text} from 'react-native-paper';
import TinderCard from 'react-tinder-card';
import styled from 'styled-components/native';
import axios from 'axios';
import styles from '../../assets/Styles';
import SparkSplash from '../../components/SparkSplash';

const Container = styled.View`
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
`;

const Header = styled.Text`
  color: #000;
  font-size: 30px;
  margin-bottom: 30px;
`;

const CardContainer = styled.View`
  width: 90%;
  max-width: 260px;
  height: 300px;
`;

const Card = styled.View`
  position: absolute;
  background-color: #fff;
  width: 100%;
  max-width: 260px;
  height: 300px;
  shadow-color: black;
  shadow-opacity: 0.2;
  shadow-radius: 20px;
  border-radius: 20px;
  resize-mode: cover;
`;

const CardImage = styled.ImageBackground`
  width: 100%;
  height: 100%;
  overflow: hidden;
  border-radius: 20px;
`;

const CardTitle = styled.Text`
  position: absolute;
  bottom: 0;
  margin: 10px;
  color: black;
`;

const Buttons = styled.View`
  margin: 20px;
  z-index: -100;
`;

const InfoText = styled.Text`
  height: 28px;
  justify-content: center;
  display: flex;
  z-index: -100;
`;

const alreadyRemoved = []; // This fixes issues with updating characters state forcing it to use the current state and not the state that was active when the card was created.

const MatchScreen = () => {
  const [characters, setCharacters] = useState([]);
  const [lastDirection, setLastDirection] = useState();
  const [minAge, setMinAge] = useState('');
  const [maxAge, setMaxAge] = useState('');
  const [range, setRange] = useState('');
  const [gender, setGender] = useState('');
  const [idToDelete, setIdToDelete] = useState('');
  const [nameToDelete, setNameToDelete] = useState('');
  const [user, setUser] = useState('');
  const [match, setMatch] = useState('');
  const [visible, setVisible] = React.useState(false);
  const containerStyle = {backgroundColor: 'white', padding: 20};
  const [isLoading, setLoading] = useState(true);
  const userId = user.id;

  const showModal = () => setVisible(true);
  const hideModal = () => setVisible(false);

  useEffect(() => {
    getData1();
    getData2();
    getData3();
    getData4();
    getUser();
  }, []);

  const getUser = async () => {
    try {
      AsyncStorage.getItem('token').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setUser(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };

  const getData1 = async () => {
    try {
      AsyncStorage.getItem('minAge').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setMinAge(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };

  const getData2 = async () => {
    try {
      AsyncStorage.getItem('maxAge').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setMaxAge(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };

  const getData3 = async () => {
    try {
      AsyncStorage.getItem('range').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setRange(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };

  const getData4 = async () => {
    try {
      await AsyncStorage.getItem('gender').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setGender(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };

  useEffect(() => {
    if (user?.id !== null) {
      axios
        .get(
          `https://spark-api-qv6.conveyor.cloud/api/User/filterby=${gender}&${minAge}&${maxAge}&${range}&${userId}`,
        )
        .then(function (response) {
          console.log('Winners fetched');
          setCharacters(response.data);
          console.log(response.data);
          setLoading(false);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }, [user?.id]);

  useEffect(() => {
    if (lastDirection == 'right') {
      axios
        .post(
          `https://spark-api-qv6.conveyor.cloud/match=id&lid?id=${user.id}&lId=${idToDelete}`,
        )
        .then(function (response) {
          console.log(response.status);
          setMatch(response);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }, [idToDelete]);

  useEffect(() => {
    if (match.status === 200) {
      showModal();
    } else {
      console.log('error');
    }
  }, [match.status]);

  console.log(user.id);

  console.log(match);
  console.log(lastDirection);

  const swiped = (direction, idToDelete, nameToDelete) => {
    console.log('removing: ' + idToDelete);
    setLastDirection(direction);
    setIdToDelete(idToDelete);
    setNameToDelete(nameToDelete);
  };

  const outOfFrame = name => {
    console.log(name + ' left the screen!');
  };
  if (isLoading) {
    return <SparkSplash />;
  }
  return (
    <View style={{flex: 1}}>
      <Container>
        <View
          style={{
            alignSelf: 'stretch',
            backgroundColor: '#5e5e5e',
            justifyContent: 'center',
            alignItems: 'center',
          }}>
          <Header style={{padding: 10}}>
            <Image
              source={require('../../assets/yellow-lightning-png-images-928255.png')}
              style={{width: 25, height: 50}}
            />
            <Text
              style={{fontFamily: 'Roboto', color: '#ffd500', marginTop: 30}}>
              {'  '}
              Spark
            </Text>
          </Header>
        </View>

        <CardContainer>
          {characters.map(character => (
            <TinderCard
              key={character.id}
              onSwipe={dir => swiped(dir, character.id, character.name)}
              onCardLeftScreen={() => outOfFrame(character.id)}>
              <Card>
                <CardImage source={require('../../assets/user.png')}>
                  <CardTitle>{character.name}</CardTitle>
                </CardImage>
              </Card>
            </TinderCard>
          ))}
        </CardContainer>
        {lastDirection ? (
          <InfoText>You swiped {lastDirection}</InfoText>
        ) : (
          <InfoText />
        )}
      </Container>
      <Provider>
        <Portal>
          <Modal
            visible={visible}
            onDismiss={hideModal}
            contentContainerStyle={containerStyle}>
            <View style={{alignItems: 'center'}}>
              <Text style={{color: 'black', fontSize: 20}}>
                Tebrikler {nameToDelete} ile eşleştin!!!!{' '}
              </Text>
            </View>
            <View style={{alignItems: 'center'}}>
              <Button
                style={styles.button}
                mode="contained"
                onPress={() => {
                  hideModal();
                }}>
                Okay
              </Button>
            </View>
          </Modal>
        </Portal>
      </Provider>
    </View>
  );
};

export default MatchScreen;

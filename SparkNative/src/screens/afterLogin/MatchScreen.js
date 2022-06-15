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
import ProfileItem from '../../components/ProfileItem';
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
  const[opposite ,setOpposite] = useState('');
  const [idToDelete, setIdToDelete] = useState('');
  const [nameToDelete, setNameToDelete] = useState('');
  const [user, setUser] = useState('');
  const [match, setMatch] = useState('');
  const [visible, setVisible] = React.useState(false);
  const containerStyle = {backgroundColor: 'white', padding: 20};
  const [isLoading, setLoading] = useState(true);
  const userId = user.id;
  const [profileImage, setProfileImage] = useState(
    'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAwBQTFRF7c5J78kt+/Xm78lQ6stH5LI36bQh6rcf7sQp671G89ZZ8c9V8c5U9+u27MhJ/Pjv9txf8uCx57c937Ay5L1n58Nb67si8tVZ5sA68tJX/Pfr7dF58tBG9d5e8+Gc6chN6LM+7spN1pos6rYs6L8+47hE7cNG6bQc9uFj7sMn4rc17cMx3atG8duj+O7B686H7cAl7cEm7sRM26cq/vz5/v767NFY7tJM78Yq8s8y3agt9dte6sVD/vz15bY59Nlb8txY9+y86LpA5LxL67pE7L5H05Ai2Z4m58Vz89RI7dKr+/XY8Ms68dx/6sZE7sRCzIEN0YwZ67wi6rk27L4k9NZB4rAz7L0j5rM66bMb682a5sJG6LEm3asy3q0w3q026sqC8cxJ6bYd685U5a457cIn7MBJ8tZW7c1I7c5K7cQ18Msu/v3678tQ3aMq7tNe6chu6rgg79VN8tNH8c0w57Q83akq7dBb9Nld9d5g6cdC8dyb675F/v327NB6////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/LvB3QAAAMFJREFUeNpiqIcAbz0ogwFKm7GgCjgyZMihCLCkc0nkIAnIMVRw2UhDBGp5fcurGOyLfbhVtJwLdJkY8oscZCsFPBk5spiNaoTC4hnqk801Qi2zLQyD2NlcWWP5GepN5TOtSxg1QwrV01itpECG2kaLy3AYiCWxcRozQWyp9pNMDWePDI4QgVpbx5eo7a+mHFOqAxUQVeRhdrLjdFFQggqo5tqVeSS456UEQgWE4/RBboxyC4AKCEI9Wu9lUl8PEGAAV7NY4hyx8voAAAAASUVORK5CYII=',
  );

  const showModal = () => setVisible(true);
  const hideModal = () => setVisible(false);
  useEffect(() => {
    getData1();
    getData2();
    getData3();
    getData4();
    getUser();
    
  }, []);
console.log(user.gender)
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
        else{
          setMinAge('18')
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
        else{
          setMaxAge('80')
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
        else{
          setRange('10000')
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
        else{
          setGender('man');
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
          `https://spark-api.conveyor.cloud/api/User/filterby=${gender}&${minAge}&${maxAge}&${range}&${userId}`,
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
          `https://spark-api.conveyor.cloud/match=id&lid?id=${user.id}&lId=${idToDelete}`,
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
  console.log(gender);
  console.log(range);
  console.log(minAge);
  console.log(maxAge);

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
          {characters.map(character => {
            // axios
            //   .get(
            //     `https://spark-api-qv6.conveyor.cloud/getImage&Resources%5C%5CImages%5C%5C${character.imagePath}.jpg`,
            //   )
            //   .then(function (response) {
            //     console.log(response.data);
            //     setProfileImage(response.data);
            //   })
            //   .catch(function (error) {
            //     console.log(error);
            //   });
            return (
              <TinderCard
                key={character.id}
                onSwipe={dir => swiped(dir, character.id, character.name)}
                onCardLeftScreen={() => outOfFrame(character.id)}>
                <Card>
                  <CardImage source={{uri: profileImage}}>
                    <CardTitle>{character.name}</CardTitle>
                  </CardImage>
                </Card>
              </TinderCard>
            );
          })}
        </CardContainer>
        {lastDirection ? (
          <InfoText>You swiped {lastDirection}</InfoText>
        ) : (
          <InfoText />
        )}
      </Container>
      {/* <View  >
      {characters.map(character => (
      <ProfileItem  
      
            matches={'Standart User'}
            name={character.name}
            lastname={characters.lastName}
            age={characters.age}
            location={characters.location}
            info1={characters.email}
            info2={characters.gender}
            info3={characters.phone}
            gender={characters.gender}
           />
           ))}
          </View> */}
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

import React, {useState, useEffect, Component, useFocusEffect} from 'react';
import {useNavigation} from '@react-navigation/native';
import {Button, TextInput, Text} from 'react-native-paper';
import styles from '../../assets/Styles';
import {
  ScrollView,
  TouchableOpacity,
  ImageBackground,
  View,
  FlatList,
} from 'react-native';
import Message from '../../components/Message';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';
import axios from 'axios';
import AsyncStorage from '@react-native-async-storage/async-storage';
import SparkSplash from '../../components/SparkSplash';

const ChatScreen = props => {
  const navigation = useNavigation();
  const [winUsers, setWinUsers] = useState([]);
  const [user, setUser] = useState('');
  const [data, setData] = useState('');
  const [isLoading, setLoading] = useState(true);
  var profileImages = [];
  const [profileImage, setProfileImage] = useState(
    'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAwBQTFRF7c5J78kt+/Xm78lQ6stH5LI36bQh6rcf7sQp671G89ZZ8c9V8c5U9+u27MhJ/Pjv9txf8uCx57c937Ay5L1n58Nb67si8tVZ5sA68tJX/Pfr7dF58tBG9d5e8+Gc6chN6LM+7spN1pos6rYs6L8+47hE7cNG6bQc9uFj7sMn4rc17cMx3atG8duj+O7B686H7cAl7cEm7sRM26cq/vz5/v767NFY7tJM78Yq8s8y3agt9dte6sVD/vz15bY59Nlb8txY9+y86LpA5LxL67pE7L5H05Ai2Z4m58Vz89RI7dKr+/XY8Ms68dx/6sZE7sRCzIEN0YwZ67wi6rk27L4k9NZB4rAz7L0j5rM66bMb682a5sJG6LEm3asy3q0w3q026sqC8cxJ6bYd685U5a457cIn7MBJ8tZW7c1I7c5K7cQ18Msu/v3678tQ3aMq7tNe6chu6rgg79VN8tNH8c0w57Q83akq7dBb9Nld9d5g6cdC8dyb675F/v327NB6////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/LvB3QAAAMFJREFUeNpiqIcAbz0ogwFKm7GgCjgyZMihCLCkc0nkIAnIMVRw2UhDBGp5fcurGOyLfbhVtJwLdJkY8oscZCsFPBk5spiNaoTC4hnqk801Qi2zLQyD2NlcWWP5GepN5TOtSxg1QwrV01itpECG2kaLy3AYiCWxcRozQWyp9pNMDWePDI4QgVpbx5eo7a+mHFOqAxUQVeRhdrLjdFFQggqo5tqVeSS456UEQgWE4/RBboxyC4AKCEI9Wu9lUl8PEGAAV7NY4hyx8voAAAAASUVORK5CYII=',
  );
  useEffect(() => {
    getData();
  }, []);

  useEffect(() => {
    getWinMatches();
  }, [user]);

  const onClick = (id, name, lastname, imagePath) => {
    navigation.navigate('Texting', {
      itemId: id,
      itemName: name,
      itemLastName: lastname,
      itemImagePath: imagePath,
    });
    getWinMatches();
  };

  const getData = async () => {
    try {
      console.log('getData');
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

  const getWinMatches = async () => {
    console.log('getData');
    axios
      .get(`https://spark-api.conveyor.cloud/getWinMatches=${user.id}`)
      .then(function (response) {
        console.log('Winners fetched');
        setWinUsers(response.data);
        console.log(response.data);
        setLoading(false);
      })
      .catch(function (error) {
        console.log(error);
      });
  };
  if (isLoading) {
    return <SparkSplash />;
  }
  return (
    <ImageBackground
      source={require('../../assets/beyaz.jpg')}
      style={styles.bg}>
      <View style={styles.containerMessages}>
        <ScrollView>
          <View style={styles.top}>
            <Text style={styles.title}>Messages {user.name}</Text>
            <TouchableOpacity>
              <Text style={styles.icon}>
                <Icon name="optionsV" />
              </Text>
            </TouchableOpacity>
          </View>
          {winUsers.map((item, index) => {
            // axios
            //   .get(
            //     `https://spark-api-qv6.conveyor.cloud/getImage&Resources%5C%5CImages%5C%5C${item.imagePath}.jpg`,
            //   )
            //   .then(function (response) {
            //     console.log(response.data);
            //     setProfileImage(response.data);
            //   })
            //   .catch(function (error) {
            //     console.log(error);
            //   });
            return (
              <TouchableOpacity
                key={index}
                onPress={() => {
                  onClick(item.id, item.name, item.lastName, item.imagePath);
                }}>
                <Message
                  image={{uri: profileImage}}
                  name={item.name}
                  lastName={item.lastName}
                  lastMessage={item.lastMessage.substring(0, 40)}
                />
              </TouchableOpacity>
            );
          })}
        </ScrollView>
      </View>
    </ImageBackground>
  );
};

export default ChatScreen;

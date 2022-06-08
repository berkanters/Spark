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

const ChatScreen = props => {
  const navigation = useNavigation();
  const [winUsers, setWinUsers] = useState([]);
  const [user, setUser] = useState('');
  const [data, setData] = useState('');

  useEffect(() => {
    getData();
  }, []);

  useEffect(() => {
    getWinMatches();
  }, [user]);

  const onClick = (id, name, lastname) => {
    navigation.navigate('Texting', {
      itemId: id,
      itemName: name,
      itemLastName: lastname,
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
      .get(`https://spark-api-qv6.conveyor.cloud/getWinMatches=${user.id}`)
      .then(function (response) {
        console.log('Winners fetched');
        setWinUsers(response.data);
        console.log(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  };

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
          {winUsers.map((item, index) => (
            <TouchableOpacity
              key={item.id}
              onPress={() => {
                onClick(item.id, item.name, item.lastName);
              }}>
              <Message
                image={item.image}
                name={item.name}
                lastName={item.lastName}
                lastMessage={item.lastMessage.substring(0, 40)}
              />
            </TouchableOpacity>
          ))}
        </ScrollView>
      </View>
    </ImageBackground>
  );
};

export default ChatScreen;

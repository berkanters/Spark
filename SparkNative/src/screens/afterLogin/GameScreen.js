import React, { useState, useMemo, useEffect } from 'react';
import styles from '../../assets/Styles';

import {
  ScrollView,
  View,
  Text,
  TouchableOpacity,
  ImageBackground,
  FlatList
} from 'react-native';
import CardItem from '../../components/CardItem';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';
import  Axios  from 'axios';
import AsyncStorage from '@react-native-async-storage/async-storage';



const GameScreen = () => {
  const [users, setUsers] = useState('');
  const [user, setUser] = useState('');

  const getUser = async () => { 
    try {
      AsyncStorage.getItem('token').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setUser(veri)
          
        }
      });
    } catch (e) {
      // error reading value
    }
  };

useEffect(() => {
  getUser();}, []);
  useEffect(() => {
    
    if(user?.id !== null){
Axios.get(`https://spark-api.conveyor.cloud/getmymatcheswithuser=${user.id}`).then(res=>{
  console.log(res.data)
  setUsers(res.data)
}) .catch(function (error) {
  console.log(error);
});
    }
  },[user?.id]);

  return (
    <ImageBackground
      source={require('../../assets/beyaz.jpg')}
      style={styles.bg}
    >
      <View style={styles.containerMatches}>
        <ScrollView>
          <View style={styles.top}>
            <Text style={styles.title}>Matches</Text>
            <TouchableOpacity>
              <Text style={styles.icon}>
                <Icon name="optionsV" />
              </Text>
            </TouchableOpacity>
          </View>

          <FlatList
            numColumns={2}
            data={users}
            keyExtractor={(item, index) => index.toString()}
            renderItem={({ item }) => (
              <TouchableOpacity>
                <CardItem
                  image={item.image}
                  name={item.name}
                  lastName={item.lastName}
                  status={item.age}
                  variant
                />
              </TouchableOpacity>
            )}
          />
        </ScrollView>
      </View>
    </ImageBackground>
  );
};
export default GameScreen;
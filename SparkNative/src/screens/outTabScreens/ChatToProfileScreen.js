import AsyncStorage from '@react-native-async-storage/async-storage';
import React, {useState, useEffect, Component} from 'react';
import {useNavigation} from '@react-navigation/native';
import styles from '../../assets/Styles';
import axios from 'axios';
import {
  ScrollView,
  View,
  Text,
  Alert,
  ImageBackground,
  TouchableOpacity,
} from 'react-native';
import ProfileItem2 from '../../components/ProfileItem2';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';
import {getDrawerStatusFromState} from '@react-navigation/drawer';
import SparkSplash from '../../components/SparkSplash';

const ChatToProfileScreen = props => {
  const navigation = useNavigation();
  const [user2id, setUser2id] = useState('');
  const [user2name, setUser2name] = useState('');
  const [user2lastName, setUser2lastName] = useState('');
  const [user2age, setUser2age] = useState('');
  const [user2gender, setUser2gender] = useState('');
  const [user2, setUser2] = useState('');
  const [distance, setDistance] = useState('');
  const [user, setUser] = useState('');
  const [isLoading, setLoading] = useState(true);

  useEffect(() => {
    let isCancelled = false;
    getData();
    return () => {
      isCancelled = true;
    };
  }, []);
  useEffect(() => {
    axios
      .get(`https://spark-api.conveyor.cloud/api/User/getbyid=${user2id}`)
      .then(function (response) {
        console.log('User2 fetched');
        setUser2(response.data);
        console.log(response.data);
        console.log('---');
        console.log(user2);
      })
      .catch(function (error) {
        console.log(error);
      });
  }, [user2id]);
  useEffect(() => {
    console.log('calculating distance', user.id, user2id);
    axios
      .get(
        `https://spark-api.conveyor.cloud/location=${user.id}&${user2id}`,
      )
      .then(function (response) {
        console.log('Distance fetched');
        setDistance(response.data);
        console.log(response.data);
        setLoading(false);
      })
      .catch(function (error) {
        console.log(error);
      });
  }, [user.id, user2id]);

  const getData = async () => {
    try {
      console.log('getData');
      AsyncStorage.getItem('token').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setUser2id(props.route.params.user2id);
          setUser(veri);
          axios
            .get(
              `https://spark-api.conveyor.cloud/api/User/getbyid=${user2id}`,
            )
            .then(function (response) {
              console.log('User2 fetched');
              setUser2(response.data);
              console.log(response.data);
              console.log('---');
              console.log(user2);
            })
            .catch(function (error) {
              console.log(error);
            });
        }
      });
    } catch (e) {
      // error reading value
    }
  };
  if (isLoading) {
    return <SparkSplash />;
  }
  return (
    <View>
      <View style={styles.containerProfile}>
        <ImageBackground
          source={require('../../assets/user.png')}
          style={styles.photo}>
          <View style={styles.top}>
            <TouchableOpacity>
              <Text style={styles.topIconLeft}>
                <Icon name="chevronLeft" />
              </Text>
            </TouchableOpacity>

            <TouchableOpacity>
              <Text style={styles.topIconRight}>
                <Icon name="optionsV" />
              </Text>
            </TouchableOpacity>
          </View>
        </ImageBackground>

        <ProfileItem2
          matches={'Game won !!!'}
          name={user2.name}
          lastname={user2.lastName}
          age={user2.age}
          location={user.location}
          info2={user2.gender}
          info3={distance}
        />
      </View>
    </View>
  );
};
export default ChatToProfileScreen;

// axios.get(`https://spark-api-qv6.conveyor.cloud/api/User/getbyid=${user2id}`).then(function (response) {
//               setUser2(response.data)}
//setUser2id(props.route.params.user2id);

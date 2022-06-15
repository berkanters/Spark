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
  const [user2imagePath, setUser2imagePath] = useState('');
  const [user2, setUser2] = useState('');
  const [distance, setDistance] = useState('');
  const [user, setUser] = useState('');
  const [isLoading, setLoading] = useState(true);
  const [isPhotoLoading, setPhotoLoading] = useState(true);
  const [profileImage, setProfileImage] = useState(
    'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAwBQTFRF7c5J78kt+/Xm78lQ6stH5LI36bQh6rcf7sQp671G89ZZ8c9V8c5U9+u27MhJ/Pjv9txf8uCx57c937Ay5L1n58Nb67si8tVZ5sA68tJX/Pfr7dF58tBG9d5e8+Gc6chN6LM+7spN1pos6rYs6L8+47hE7cNG6bQc9uFj7sMn4rc17cMx3atG8duj+O7B686H7cAl7cEm7sRM26cq/vz5/v767NFY7tJM78Yq8s8y3agt9dte6sVD/vz15bY59Nlb8txY9+y86LpA5LxL67pE7L5H05Ai2Z4m58Vz89RI7dKr+/XY8Ms68dx/6sZE7sRCzIEN0YwZ67wi6rk27L4k9NZB4rAz7L0j5rM66bMb682a5sJG6LEm3asy3q0w3q026sqC8cxJ6bYd685U5a457cIn7MBJ8tZW7c1I7c5K7cQ18Msu/v3678tQ3aMq7tNe6chu6rgg79VN8tNH8c0w57Q83akq7dBb9Nld9d5g6cdC8dyb675F/v327NB6////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/LvB3QAAAMFJREFUeNpiqIcAbz0ogwFKm7GgCjgyZMihCLCkc0nkIAnIMVRw2UhDBGp5fcurGOyLfbhVtJwLdJkY8oscZCsFPBk5spiNaoTC4hnqk801Qi2zLQyD2NlcWWP5GepN5TOtSxg1QwrV01itpECG2kaLy3AYiCWxcRozQWyp9pNMDWePDI4QgVpbx5eo7a+mHFOqAxUQVeRhdrLjdFFQggqo5tqVeSS456UEQgWE4/RBboxyC4AKCEI9Wu9lUl8PEGAAV7NY4hyx8voAAAAASUVORK5CYII=',
  );
  useEffect(() => {
    let isCancelled = false;
    getData();
    return () => {
      isCancelled = true;
    };
  }, []);
  useEffect(() => {
    axios
      .get(`https://spark-api-qv6.conveyor.cloud/api/User/getbyid=${user2id}`)
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
        `https://spark-api-qv6.conveyor.cloud/location=${user.id}&${user2id}`,
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

  useEffect(() => {
    if (isPhotoLoading) {
      console.log(
        `https://spark-api-qv6.conveyor.cloud/getImage&${props.route.params.user2ImagePath}.jpg`,
        props.route.params.user2ImagePath,
      );
      axios
        .get(
          `https://spark-api-qv6.conveyor.cloud/getImage&Resources%5C%5CImages%5C%5C${props.route.params.user2ImagePath}.jpg`,
        )
        .then(function (response) {
          console.log(response.data);
          setProfileImage(response.data);

          setPhotoLoading(false);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  });
  const Unmatch = () => {
    axios.delete(`https://spark-api-qv6.conveyor.cloud/unmatch=${user.id}&${user2id}`)
      .then(function (response) {
        console.log(response.data);
        navigation.navigate('Profile');
      }).catch(function (error) {
        console.log(error);
      });
  }
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
              `https://spark-api-qv6.conveyor.cloud/api/User/getbyid=${user2id}`,
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
        <ImageBackground source={{uri: profileImage}} style={styles.photo}>
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
        <View style={styles.actionsProfile}>
            <TouchableOpacity
              style={{color: 'red', fontSize: 12, marginTop: 10}}
              onPress={Unmatch}>
              <Text style={{color: 'red', fontSize: 15, marginBottom: 20}}>
                Unmatch
              </Text>
            </TouchableOpacity>
          </View>
      </View>
    </View>
  );
};
export default ChatToProfileScreen;

// axios.get(`https://spark-api-qv6.conveyor.cloud/api/User/getbyid=${user2id}`).then(function (response) {
//               setUser2(response.data)}
//setUser2id(props.route.params.user2id);

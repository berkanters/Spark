import React, {useState, useMemo, useEffect} from 'react';
import styles from '../../assets/Styles';

import {
  ScrollView,
  View,
  Text,
  TouchableOpacity,
  ImageBackground,
  FlatList,
} from 'react-native';
import CardItem from '../../components/CardItem';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';
import {useNavigation} from '@react-navigation/native';
import Axios from 'axios';
import AsyncStorage from '@react-native-async-storage/async-storage';
import SparkSplash from '../../components/SparkSplash';
import {SafeAreaView} from 'react-native-safe-area-context';

const GameScreen = () => {
  const navigation = useNavigation();
  const [users, setUsers] = useState('');
  const [user, setUser] = useState('');
  const [isLoading, setLoading] = useState(true);
  const [itemId, setItemId] = useState('');
  const [profileImage, setProfileImage] = useState(
    'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAwBQTFRF7c5J78kt+/Xm78lQ6stH5LI36bQh6rcf7sQp671G89ZZ8c9V8c5U9+u27MhJ/Pjv9txf8uCx57c937Ay5L1n58Nb67si8tVZ5sA68tJX/Pfr7dF58tBG9d5e8+Gc6chN6LM+7spN1pos6rYs6L8+47hE7cNG6bQc9uFj7sMn4rc17cMx3atG8duj+O7B686H7cAl7cEm7sRM26cq/vz5/v767NFY7tJM78Yq8s8y3agt9dte6sVD/vz15bY59Nlb8txY9+y86LpA5LxL67pE7L5H05Ai2Z4m58Vz89RI7dKr+/XY8Ms68dx/6sZE7sRCzIEN0YwZ67wi6rk27L4k9NZB4rAz7L0j5rM66bMb682a5sJG6LEm3asy3q0w3q026sqC8cxJ6bYd685U5a457cIn7MBJ8tZW7c1I7c5K7cQ18Msu/v3678tQ3aMq7tNe6chu6rgg79VN8tNH8c0w57Q83akq7dBb9Nld9d5g6cdC8dyb675F/v327NB6////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/LvB3QAAAMFJREFUeNpiqIcAbz0ogwFKm7GgCjgyZMihCLCkc0nkIAnIMVRw2UhDBGp5fcurGOyLfbhVtJwLdJkY8oscZCsFPBk5spiNaoTC4hnqk801Qi2zLQyD2NlcWWP5GepN5TOtSxg1QwrV01itpECG2kaLy3AYiCWxcRozQWyp9pNMDWePDI4QgVpbx5eo7a+mHFOqAxUQVeRhdrLjdFFQggqo5tqVeSS456UEQgWE4/RBboxyC4AKCEI9Wu9lUl8PEGAAV7NY4hyx8voAAAAASUVORK5CYII=',
  );
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

  useEffect(() => {
    getUser();
  }, []);
  useEffect(() => {
    if (user?.id !== null) {
      Axios.get(
        `https://spark-api.conveyor.cloud/getmymatcheswithuser=${user.id}`,
      )
        .then(res => {
          console.log(res.data);
          setUsers(res.data);
          setLoading(false);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }, [user?.id]);

  useEffect(() => {
    console.log(itemId);
  }, [itemId]);
  if (isLoading) {
    return <SparkSplash />;
  }
  return (
    <SafeAreaView source={require('../../assets/beyaz.jpg')} style={styles.bg}>
      <View style={styles.containerMatches}>
        <View>
          <View style={styles.top}>
            <Text style={styles.title}>Matches</Text>
            <TouchableOpacity>
              <Text style={styles.icon}>
                <Icon name="optionsV" />
              </Text>
            </TouchableOpacity>
          </View>
          {/* <ScrollView>
            {users.map((item, index) => {
              Axios.get(
                `https://spark-api-qv6.conveyor.cloud/getImage&Resources%5C%5CImages%5C%5C${item.imagePath}.jpg`,
              )
                .then(function (response) {
                  console.log(response.data);
                  setProfileImage(response.data);
                })
                .catch(function (error) {
                  console.log(error);
                });
              return (
                <TouchableOpacity
                  key={index}
                  onPress={() => {
                    navigation.navigate('ChatToProfile', {user2id: item.id});
                  }}>
                  <CardItem
                    image={{uri: profileImage}}
                    name={item.name}
                    lastName={item.lastName}
                    status={item.age}
                    variant
                  />
                </TouchableOpacity>
              );
            })}
          </ScrollView> */}
          <FlatList
            numColumns={2}
            data={users}
            keyExtractor={(item, index) => index.toString()}
            renderItem={({item}) => {
              // Axios.get(
              //   `https://spark-api-qv6.conveyor.cloud/getImage&Resources%5C%5CImages%5C%5C${item.imagePath}.jpg`,
              // )
              //   .then(function (response) {
              //     console.log(response.data);
              //     setProfileImage(response.data);
              //   })
              //   .catch(function (error) {
              //     console.log(error);
              //   });
              return (
                <TouchableOpacity
                  onPress={() => {
                    navigation.navigate('ChatToProfile', {
                      user2id: item.id,
                      user2ImagePath: item.imagePath,
                    });
                  }}>
                  <CardItem
                    image={{uri: profileImage}}
                    name={item.name}
                    lastName={item.lastName}
                    status={item.age}
                    variant
                  />
                </TouchableOpacity>
              );
            }}
          />
        </View>
      </View>
      <View style={{margin: 50}} />
    </SafeAreaView>
  );
};
export default GameScreen;

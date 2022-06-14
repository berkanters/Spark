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

          <FlatList
            numColumns={2}
            data={users}
            keyExtractor={(item, index) => index.toString()}
            renderItem={({item}) => (
              <TouchableOpacity
                onPress={() => {
                  navigation.navigate('ChatToProfile', {user2id: item.id});
                }}>
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
        </View>
      </View>
      <View style={{margin: 50}} />
    </SafeAreaView>
  );
};
export default GameScreen;

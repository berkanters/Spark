import AsyncStorage from '@react-native-async-storage/async-storage';
import React, {useState, useEffect, Component} from 'react';
import {useNavigation} from '@react-navigation/native';
import styles from '../../assets/Styles';
import axios from 'axios';
import {CommonActions} from '@react-navigation/native';
import {
  ScrollView,
  View,
  Text,
  Alert,
  ImageBackground,
  TouchableOpacity,
} from 'react-native';
import ProfileItem from '../../components/ProfileItem';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';
import {getDrawerStatusFromState} from '@react-navigation/drawer';
import Geolocation from '@react-native-community/geolocation';
import {Modal, Portal, Button, Provider} from 'react-native-paper';
import Slider from '@react-native-community/slider';
import {min} from 'react-native-reanimated';
import DropDownPicker from 'react-native-dropdown-picker';
import {faLongArrowAltUp} from '@fortawesome/free-solid-svg-icons';
import SparkSplash from '../../components/SparkSplash';

const ProfileScreen = props => {
  const [coordinates, setCoordinates] = useState('');
  const {age, image, info1, info2, info3, info4, location, match, name} =
    Demo[7];
  const [user, setUser] = useState('');
  const navigation = useNavigation();
  const [minAge, setMinAge] = useState('');
  const [maxAge, setMaxAge] = useState('');
  const [range, setRange] = useState('');
  const [visible, setVisible] = React.useState(false);
  const [opens, setOpens] = useState(false);
  const [value, setValue] = useState(null);
  const [items, setItems] = useState([
    {label: 'Man', value: 'man'},
    {label: 'Woman', value: 'woman'},
    {label: 'Other', value: 'other'},
  ]);
  const [data, setData] = useState('');
  const [isLoading, setLoading] = useState(true);
  const showModal = () => setVisible(true);
  const hideModal = () => setVisible(false);
  const containerStyle = {backgroundColor: 'white', padding: 20};

  // const [testValue, setTestValue] = useState('');
  // const savedProfile = AsyncStorage.getItem('token');
  // const profile = JSON.parse(savedProfile);
  // console.log((profile));
  // AsyncStorage.getItem('token').then(value => {
  //   setTestValue(value);
  // });

  useEffect(() => {
    let isCancelled = false;
    getData();
    return () => {
      isCancelled = true;
    };
  }, []);

  useEffect(() => {
    let isCancelled = false;
    getLocation();
    return () => {
      isCancelled = true;
    };
  }, [user?.id]);

  const getLocation = async () => {
    console.log('getLocation');
    Geolocation.getCurrentPosition(
      position => {
        const initialPosition = JSON.stringify(position);
        setCoordinates(initialPosition);
        axios
          .put(
            `https://spark-api-qv6.conveyor.cloud/SetLocation?userId=${user.id}&latitude=${position.coords.latitude}&longitude=${position.coords.longitude}`,
          )
          .then(function (response) {
            console.log('Location Setted to DB');

            axios
              .get(
                `https://spark-api-qv6.conveyor.cloud/api/User/getbyid=${user.id}`,
              )
              .then(function (response) {
                setData(response);
                const jsonValue = JSON.stringify(response.data);
                AsyncStorage.setItem('token', jsonValue);
              })
              .catch(function (error) {
                console.log(error);
              });
          })
          .catch(function (error) {
            console.log(error);
          });
      },
      error => Alert.alert('Error', JSON.stringify(error)),
      {enableHighAccuracy: true, timeout: 20000, maximumAge: 1000},
    );
  };

  //       axios
  //         .put(
  //           `https://spark-api-qv6.conveyor.cloud/SetLocation?userId=${user.id}&latitude=${position.coords.latitude}&longitude=${position.coords.longitude}`,
  //         )
  //         .then(function (response) {
  //           console.log(response);
  //         })
  //         .catch(function (error) {
  //           console.log(error);
  //         });
  //     },
  //     error => Alert.alert('Error', JSON.stringify(error)),
  //     {enableHighAccuracy: true, timeout: 20000, maximumAge: 1000},
  //   );
  // };
  console.log(minAge);
  const getData = async () => {
    try {
      console.log('getData');
      AsyncStorage.getItem('token').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setUser(veri);
          setLoading(false);
        }
      });
    } catch (e) {
      // error reading value
    }
  };
  const onClick = () => {
    const jsonMinAge = JSON.stringify(minAge);
    const jsonMaxAge = JSON.stringify(maxAge);
    const jsonRange = JSON.stringify(range);
    const jsonGender = JSON.stringify(value);
    AsyncStorage.setItem('minAge', jsonMinAge);
    AsyncStorage.setItem('maxAge', jsonMaxAge);
    AsyncStorage.setItem('range', jsonRange);
    AsyncStorage.setItem('gender', jsonGender);
    hideModal();
  };

  const logOut = async () => {
    try {
      await AsyncStorage.removeItem('token');
    } catch (e) {
      // remove error
    }
    console.log('Done.');
    navigation.reset({index: 0, routes: [{name: 'Landing'}]});
  };

  //  const getData = async () => {
  //    try {
  //      const jsonValue = await AsyncStorage.getItem("token").then((value) =>{jsonValue != null ? JSON.parse(jsonValue) : null }).then(setUser(jsonValue))
  //      return console.log(user)
  //    } catch(e) {
  //      // error reading value
  //   }

  //  }

  // const readData = async () => {
  //   try {
  //     const userAge = await AsyncStorage.getItem('token')

  //     if (userAge !== null) {
  //       setUser(userAge)
  //     }
  //   } catch (e) {
  //     alert('Failed to fetch the data from storage')
  //   }
  // }
  // console.log(user)

  // const storeData = async () => {
  //     const user =  await AsyncStorage.getItem('token');
  //     if(user){
  //         user = JSON.parse(user);
  console.log(user);
  //     }

  // }

  // const retriveData = async () => {
  // try {
  //   const value = await AsyncStorage.getItem("token");
  //   if (value !== null) {
  //       // We have data!!
  //       return console.log(value);
  //   }
  // } catch (error) {
  //   // Error retrieving data
  // }
  // }

  //  useEffect(()=>{
  //  AsyncStorage.getItem("token").then((value) => { setUser(value) });
  //   console.log(user)
  //   JSON.parse(setUser)

  //  },[setUser]);
  // const retriveData = async () => {
  //   const value = await AsyncStorage.getItem("token");
  //   return JSON.parse(value)
  // }

  //  AsyncStorage.getItem('token').then((token) => JSON.parse(token)).then((token) => JSON.parse(token));
  if (isLoading) {
    return <SparkSplash />;
  }
  return (
    <View>
      <View style={styles.containerProfile}>
        <ScrollView>
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

          <ProfileItem
            matches={'Standart User'}
            name={user.name}
            lastname={user.lastName}
            age={user.age}
            location={user.location}
            info1={user.email}
            info2={user.gender}
            info3={user.phone}
            minage={minAge}
            maxage={maxAge}
            range={range}
            gender={value}
          />

          <View style={styles.actionsProfile}>
            <Button
              style={styles.button}
              mode="contained"
              onPress={() => navigation.navigate('ProfileEdit')}>
              Edit Profile
            </Button>

            <Button style={styles.button} mode="contained" onPress={showModal}>
              Preferences
            </Button>
          </View>
          <View style={styles.actionsProfile}>
            <TouchableOpacity
              style={{color: 'red', fontSize: 12, marginTop: 10}}
              onPress={logOut}>
              <Text style={{color: 'red', fontSize: 15, marginBottom: 20}}>
                Logout
              </Text>
            </TouchableOpacity>
          </View>
        </ScrollView>

        <Provider>
          <Portal>
            <Modal
              visible={visible}
              onDismiss={hideModal}
              contentContainerStyle={containerStyle}>
              <View
                style={{
                  justifyContent: 'center',
                  alignItems: 'center',
                  marginBottom: 20,
                }}>
                <Text style={{color: '#000', fontSize: 20}}>
                  Set Your Filters
                </Text>
              </View>

              <View flexDirection="row">
                <Slider
                  style={{width: 200, height: 80}}
                  minimumValue={18}
                  maximumValue={80}
                  minimumTrackTintColor="#ffd500"
                  maximumTrackTintColor="#ffd500"
                  thumbTintColor="#ffd500"
                  onValueChange={value => setMinAge(value)}
                  step={1}
                />
                <Text style={{color: '#000'}}>Min Age ({minAge})</Text>
              </View>
              <View flexDirection="row">
                <Slider
                  style={{width: 200, height: 80}}
                  minimumValue={18}
                  maximumValue={80}
                  minimumTrackTintColor="#ffd500"
                  maximumTrackTintColor="#ffd500"
                  thumbTintColor="#ffd500"
                  onValueChange={value => setMaxAge(value)}
                  step={1}
                />
                <Text style={{color: '#000'}}>Max Age ({maxAge})</Text>
              </View>
              <View flexDirection="row">
                <Slider
                  style={{width: 200, height: 80}}
                  minimumValue={1}
                  maximumValue={10000}
                  minimumTrackTintColor="#ffd500"
                  maximumTrackTintColor="#ffd500"
                  thumbTintColor="#ffd500"
                  onValueChange={value => setRange(value)}
                  step={1}
                />
                <Text style={{color: '#000'}}>Set your range ({range} KM)</Text>
              </View>
              <DropDownPicker
                style={{}}
                open={opens}
                value={value}
                items={items}
                setOpen={setOpens}
                setValue={setValue}
                setItems={setItems}
              />
              <Button
                style={styles.button}
                mode="contained"
                onPress={() => {
                  onClick();
                }}>
                Okay
              </Button>
            </Modal>
          </Portal>
        </Provider>
      </View>
    </View>
  );
};
export default ProfileScreen;

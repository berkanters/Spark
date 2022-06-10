import React, {useState, useEffect} from 'react';
import {View} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import {TextInput, Button, Text} from 'react-native-paper';
import {TouchableOpacity} from 'react-native-gesture-handler';
import DatePicker from 'react-native-date-picker';
import DropDownPicker from 'react-native-dropdown-picker';
import axios from 'axios';
import {SafeAreaView} from 'react-native-safe-area-context';
import AsyncStorage from '@react-native-async-storage/async-storage';
import SparkSplash from '../../components/SparkSplash';

const ProfileEditScreen = props => {
  const navigation = useNavigation();
  const [email, setEmail] = useState('');
  const [name, setName] = useState('');
  const [lastname, setLastname] = useState('');
  const [phone, setPhone] = useState('');
  const [user, setUser] = useState('');
  const [isLoading, setLoading] = useState(true);

  useEffect(() => {
    let isCancelled = false;
    getData();
    return () => {
      isCancelled = true;
    };
  }, [user?.id]);

  const getData = async () => {
    try {
      console.log('getData');
      AsyncStorage.getItem('token').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setUser(veri);
        }
        setName(user.name);
        setLastname(user.lastName);
        setEmail(user.email);
        setPhone(user.phone);
        setInterval(() => {
          setLoading(false);
        }, 100);
      });
    } catch (e) {
      // error reading value
    }
  };

  const saveChanges = () => {
    console.log('saveChanges');
    axios
      .put(`https://spark-api-qv6.conveyor.cloud/UpdateUser`, {
        id: user.id,
        name: name,
        lastName: lastname,
        email: email,
        password: user.password,
        age: user.age,
        gender: user.gender,
        phone: phone,
        latitude: user.latitude,
        longitude: user.longitude,
      })
      .then(function (response) {
        console.log('User updated');
        navigation.navigate('Profile');
      })
      .catch(function (error) {
        console.log(error);
      });
  };
  if (isLoading) {
    return <SparkSplash />;
  }
  return (
    <SafeAreaView style={styles.container}>
      <View style={{flex: 8, justifyContent: 'center', alignItems: 'center'}}>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Name"
          value={name}
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setName(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Lastname"
          value={lastname}
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setLastname(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="E-mail"
          value={email}
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setEmail(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Phone"
          value={phone}
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setPhone(val)}></TextInput>

        <Button style={styles.button} mode="contained" onPress={saveChanges}>
          Save Your Changes
        </Button>
        <Button
          style={styles.button}
          mode="contained"
          onPress={() => navigation.goBack()}>
          Back to Your Profile
        </Button>
      </View>
    </SafeAreaView>
  );
};

const styles = {
  container: {
    flex: 1,
    justifyContent: 'center',
    backgroundColor: 'white',
  },
  textInput: {
    width: '90%',
    marginTop: 10,
    height: 40,
  },
  button: {
    width: '60%',
    height: '5.5%',
    backgroundColor: '#ffd500',

    justifyContent: 'center',
    marginTop: 20,
    borderRadius: 20,
  },
  text: {
    fontSize: 20,
    fontWeight: 'bold',
    color: 'black',
  },
  textTou: {
    fontSize: 22,
    fontWeight: 'bold',
    color: '#ffd500',
  },
};

export default ProfileEditScreen;

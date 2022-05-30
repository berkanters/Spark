import React, {useState, useEffect} from 'react';
import {View} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import {Button, TextInput, Text, ActivityIndicator} from 'react-native-paper';
import {TouchableOpacity} from 'react-native-gesture-handler';
import axios from 'axios';

const LoginScreen = props => {
  const navigation = useNavigation();
  const [password, setPassword] = useState('');
  const [email, setEmail] = useState('');
  const [data, setData] = useState('');
  console.log(data);

  useEffect(() => {
    if (data.status === 200) {
      navigation.reset({index: 0, routes: [{name: 'tab'}]});
    } else {
      console.log('error');
    }
  }, [data.status]);
  const onClick = () => {
    axios
      .post('https://spark-api-qv6.conveyor.cloud/Login', {
        email: email,
        password: password,
      })
      .then(function (response) {
        setData(response);
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  return (
    <View style={styles.container}>
      <View style={{flex: 2, justifyContent: 'center', alignItems: 'center'}}>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="E-mail"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setEmail(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          onChangeText={val => setPassword(val)}
          mode="outlined"
          label="Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <Button style={styles.button} mode="contained" onPress={onClick}>
          Login
        </Button>
      </View>
      <View
        style={{
          flexDirection: 'row',
          flex: 1,
          justifyContent: 'center',
          alignItems: 'center',
        }}>
        <Text style={styles.text}>İf you dont have account </Text>
        <TouchableOpacity>
          <Text style={styles.textTou}>Register</Text>
        </TouchableOpacity>
      </View>
    </View>
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
    marginTop: 20,
  },
  button: {
    width: '70%',
    height: '10%',
    backgroundColor: '#ffd500',

    justifyContent: 'center',
    marginTop: 20,
    borderRadius: 15,
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
export default LoginScreen;

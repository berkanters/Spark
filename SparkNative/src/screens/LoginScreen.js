import React,{useState,useEffect} from 'react';
import {View} from 'react-native';
import {NavigationContainer, useNavigation} from '@react-navigation/native';
import {Button, TextInput, Text} from 'react-native-paper';
import {TouchableOpacity} from 'react-native-gesture-handler';
import axios from 'axios';
import { useValue } from 'react-native-reanimated';
import { string } from 'prop-types';

const LoginScreen = props => {
  const navigation = useNavigation();
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const pass=password;
  let ema=JSON.stringify(email);
  let pas=JSON.stringify(password);
  console.log('ema',ema);
  console.log('pas',pas);
  useEffect(()=>{
    
  },[])

const onClick =()=>{
  setEmail(email);
  setPassword(password);
  axios.post(`https://spark-api.conveyor.cloud/api/user/login/${ema}&${pas}`)
  .then(function (response) {
    console.log(response);
  })
  .catch(function (error) {
    console.log(error);
  });
}

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
          onChange={()=>email}></TextInput>
        <TextInput
          style={styles.textInput}
          onChange={()=>password}
          mode="outlined"
          label="Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <Button
          style={styles.button}
          mode="contained"
          onPress={onClick}>
          Login
        </Button>
      </View>
      <View
        style={{
          flex: 1,
          flexDirection: 'row',
          justifyContent: 'center',
          alignItems: 'center',
        }}>
        <Text style={styles.text}>
          If you not have accaount then{' '}
          <TouchableOpacity onPress={onClick}>
            <Text style={styles.textTou}>register</Text>
          </TouchableOpacity>{' '}
        </Text>
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
    marginTop: 10,
    fontSize: 15,
    fontWeight: 'bold',
    color: '#ffd500',
  },
};
export default LoginScreen;

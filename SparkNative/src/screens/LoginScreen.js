import React from 'react';
import {View} from 'react-native';
import {NavigationContainer, useNavigation} from '@react-navigation/native';
import {Button, TextInput, Text} from 'react-native-paper';
import {TouchableOpacity} from 'react-native-gesture-handler';

const LoginScreen = props => {
  const navigation = useNavigation();
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  useEffect(() => {
    const response = axios
      .post(
        'https://spark-api.conveyor.cloud/api/user/login',{
          name, email
        }
      )
      .then(response => (response.status === 200 ? response.data : null));

    // empty dependency array means this effect will only run once (like componentDidMount in classes)
  },);
  return (
    <View style={styles.container}>
      <View style={{flex: 2, justifyContent: 'center', alignItems: 'center'}}>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          value='email'
          label="E-mail"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChange={()=>setEmail}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <Button
          style={styles.button}
          mode="contained"
          onPress={() => navigation.navigate('Register')}>
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
          <TouchableOpacity onPress={() => navigation.navigate('Register')}>
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

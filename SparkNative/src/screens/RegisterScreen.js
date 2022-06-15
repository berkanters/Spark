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

const RegisterScreen = props => {
  const navigation = useNavigation();
  const [opens, setOpens] = useState(false);
  const [value, setValue] = useState(null);
  const [items, setItems] = useState([
    {label: 'Man', value: 'Man'},
    {label: 'Woman', value: 'Woman'},
    {label: 'Other', value: 'Other'},
  ]);
  const [date, setDate] = useState(new Date());
  const [open, setOpen] = useState(false);
  const [ndate, setNDate] = useState('');
  const tarih =
    date.getDate() + '-' + date.getMonth() + '-' + date.getFullYear();
  const [password, setPassword] = useState('');
  const [user, setUser] = useState('');
  console.log(user);

  AsyncStorage.getItem('token').then(token => {
    setUser(token);
  });

  const [passwordSecond, setPasswordSecond] = useState('');
  const [validPassword, setValidPassword] = useState(false);
  const [email, setEmail] = useState('');
  const [name, setName] = useState('');
  const [lastname, setLastname] = useState('');
  const [phone, setPhone] = useState('');
  const [data, setData] = useState('');
  const age = 2022 - date.getFullYear();
  console.log(age, 'age');
  console.log(value, 'gender');
  console.log(lastname, 'last');
  console.log(phone, 'phone');
  console.log(name, 'name');
  console.log(email, 'email');
  console.log(password, 'password');
  console.log(data);
  /*
  useEffect(()=>{
    if(data.status=== 200){
      navigation.navigate('Login',{data});  
    }else{
      alert("Yanlış Şifre")
    }
    },[data.status])


*/

  useEffect(() => {
    if (validPassword) {
      axios
        .post('https://spark-api.conveyor.cloud/Register', {
          name: name,
          lastName: lastname,
          email: email,
          password: password,
          age: age,
          gender: value,
          phone: phone,
          imagePath: 'user',
        })
        .then(function (response) {
          setData(response);
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }, [validPassword]);

  const onClick = () => {
    if (password === passwordSecond) {
      setValidPassword(true);
    } else {
      alert('Siktirgit doğru yaz şifreyi');
    }
  };

  return (
    <SafeAreaView style={styles.container}>
      <View style={{flex: 8, justifyContent: 'center', alignItems: 'center'}}>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Name"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setName(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Lastname"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setLastname(val)}></TextInput>
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
          mode="outlined"
          label="Phone"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setPhone(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setPassword(val)}></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Re-Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"
          onChangeText={val => setPasswordSecond(val)}></TextInput>

        <View
          style={{
            flex: 1,
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'row',
            paddingHorizontal: 20,
          }}>
          <View style={{flex: 1, justifyContent: 'center'}}>
            <DropDownPicker
              style={{}}
              open={opens}
              value={value}
              items={items}
              setOpen={setOpens}
              setValue={setValue}
              setItems={setItems}
            />
          </View>
          <View style={{flex: 1}}>
            <TouchableOpacity
              style={{
                borderWidth: 1,
                borderColor: 'black',
                paddingVertical: 15,
                borderRadius: 8,
                marginLeft: 5,
                alignItems: 'center',
              }}
              title="Open"
              onPress={() => setOpen(true)}>
              <Text>{ndate === false ? tarih : 'Birthday'}</Text>
            </TouchableOpacity>
            <DatePicker
              modal
              open={open}
              mode="date"
              androidVariant="iosClone"
              date={date}
              onConfirm={date => {
                setOpen(false);
                setDate(date);
                setNDate(false);
              }}
              onCancel={() => {
                setOpen(false);
              }}
            />
          </View>
        </View>

        <Button style={styles.button} mode="contained" onPress={onClick}>
          Register
        </Button>
      </View>
      <View
        style={{
          flexDirection: 'row',
          flex: 1,
          justifyContent: 'center',
          alignItems: 'center',
        }}>
        <Text style={styles.text}>If you already have an account </Text>
        <TouchableOpacity onPress={() => navigation.navigate('Login')}>
          <Text style={styles.textTou}>Login</Text>
        </TouchableOpacity>
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
export default RegisterScreen;

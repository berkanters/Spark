import React from 'react';
import {View} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import {TextInput, Button, Text} from 'react-native-paper';
import {TouchableOpacity} from 'react-native-gesture-handler';
import DatePicker from 'react-native-date-picker';
import DropDownPicker from 'react-native-dropdown-picker';
import { SafeAreaView } from 'react-native-safe-area-context';


const RegisterScreen = props => {
  const [opens, setOpens] = React.useState(false);
  const [value, setValue] = React.useState(null);
  const [items, setItems] = React.useState([
    {label: 'Man', value: 'Man'},
    {label:'Woman',value:'Woman'},
    {label:'Other',value:'Other'}
  ]);
  const [date, setDate] = React.useState(new Date());
  const [open, setOpen] = React.useState(false);
 const [name,setName]=React.useState('')
const tarih = date.getDate()+'-'+date.getMonth()+'-'+date.getFullYear()
  return (
    <View style={styles.container}>
      <View style={{flex: 7, justifyContent: 'center', alignItems: 'center'}}>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Name"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Lastname"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="E-mail"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <TextInput
          style={styles.textInput}
          mode="outlined"
          label="Re-Password"
          outlineColor="#ffd500"
          activeOutlineColor="#ffd500"
          activeUnderlineColor="ffd500"></TextInput>
        <View style={{flex:1,justifyContent:'center', alignItems:'center',flexDirection:'row',paddingHorizontal:20}}>
            <View style={{flex:1,justifyContent:'center'}}>
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
          <View style={{flex:1}}>
          <TouchableOpacity style={{borderWidth:1,borderColor:'black',paddingVertical:15,borderRadius:8,marginLeft:5,alignItems:'center'}} title="Open" onPress={() => setOpen(true)}>
           <Text >{name === false ? tarih :'Birthday'}</Text> 
          
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
              setName(false)
            }}
            onCancel={() => {
              setOpen(false);
            }}
          />
      
          </View>
        </View>

        <Button
          style={styles.button}
          mode="contained"
          onPress={() => navigation.navigate('Register')}>
          Register
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
          <TouchableOpacity onPress={() => navigation.navigate('Login')}>
            <Text style={styles.textTou}>Login</Text>
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
    marginTop: 10,
    fontSize: 17,
    fontWeight: 'bold',
    color: '#ffd500',
  },
};
export default RegisterScreen;

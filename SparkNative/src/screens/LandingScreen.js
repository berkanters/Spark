import React from 'react';
import {Text, TouchableOpacity, View, Image} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import { Button } from 'react-native-paper';

const LandingScreen = props => {
  const navigation = useNavigation();
  console.log(props?.route?.params?.data?.data.age,'doğru data')
  return (
  
    <View style={styles.container}>
      <View style={{flex:2, flexDirection:'row',alignItems:'center'}}>
      <Image source={require('../assets/yellow-lightning-png-images-928255.png')} style={{width: 200, height: 200}}/>
        <Text style={styles.text}>Spark</Text>
      </View>
      <View style={{flex:1,alignItems:'center'}}><Button style={styles.button}  mode="contained" onPress={()=>navigation.navigate('Login',{data:props?.route?.params?.data})}>Login</Button>
      <Button style={styles.button} mode="contained" onPress={()=>navigation.navigate('Register')}>Register</Button>
      </View>
    </View>
    
      
  );
};

const styles = {
  container: {
    flex: 1,
    justifyContent:'center',
    
    backgroundColor: 'white',
  },
  button: {
    width: '70%',
    height: '20%',
    backgroundColor: '#ffd500',
    
    justifyContent: 'center',
    marginTop: 20,
    borderRadius: 15,
  },
  text: {
    fontSize: 50,
    fontWeight: 'bold',
    color: '#ffd500',
  },

  backgroundImage:{
    flex: 1,
    resizeMode: 'cover',
  }
};
export default LandingScreen;

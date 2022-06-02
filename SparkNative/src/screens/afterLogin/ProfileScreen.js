import AsyncStorage from '@react-native-async-storage/async-storage';
import React, {useState, useEffect, Component} from 'react';
import styles from '../../assets/Styles';
import {
  ScrollView,
  View,
  Text,
  ImageBackground,
  TouchableOpacity
} from 'react-native';
import ProfileItem from '../../components/ProfileItem';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';
import { getDrawerStatusFromState } from '@react-navigation/drawer';



const ProfileScreen = props => {
  const {
    age,
    image,
    info1,
    info2,
    info3,
    info4,
    location,
    match,
    name
  } = Demo[7];
    const [user, setUser] = useState('');
    const [testValue, setTestValue] = useState('');
    // const savedProfile = AsyncStorage.getItem('token');
    // const profile = JSON.parse(savedProfile);
    // console.log((profile));
 AsyncStorage.getItem("token").then((value) => { setTestValue(value) });

 useEffect (()=>{
   getData();
   
 },[])



 const getData = async () => {
  try {
    AsyncStorage.getItem('token').then(value=>{
      if(value!=null){
        let veri=JSON.parse(value)
        setUser((veri))
      }
    })
    
  } catch(e) {
    // error reading value
  }
}

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
  console.log(user)
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
   
  
   return (
    <View>
      <ScrollView style={styles.containerProfile}>
        <ImageBackground source={require('../../assets/user.png')} style={styles.photo}>
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
          matches={"Standart User"}
          name={(user.name)}
          lastname={user.lastName}
          age={user.age}
          location={user.location}
          info1={user.email}
          info2={user.gender}
          info3={user.phone}
          info4={info4}
        />
   

        <View style={styles.actionsProfile}>
          <TouchableOpacity style={styles.circledButton}>
            <Text style={styles.iconButton}>
              <Icon name="optionsH" />
            </Text>
          </TouchableOpacity>

          <TouchableOpacity style={styles.roundedButton}>
            <Text style={styles.iconButton}>
              <Icon name="chat" />
            </Text>
            <Text style={styles.textButton}>Start chatting</Text>
          </TouchableOpacity>
        </View>
      </ScrollView>
    </View>
  );
};
  export default ProfileScreen;
  

   



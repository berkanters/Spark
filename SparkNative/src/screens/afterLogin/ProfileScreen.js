import AsyncStorage from '@react-native-async-storage/async-storage';
import React, {useState, useEffect} from 'react';
import {View} from 'react-native';
import {Button, TextInput, Text} from 'react-native-paper';


const ProfileScreen = props => {
    const [user, setUser] = useState('');
    console.log(user);

   AsyncStorage.getItem('token').then((token) => {setUser(token)});
        return (
            <View>
                <Text>ProfileScreen</Text>
                
            </View>
        );
    
};
export default ProfileScreen;
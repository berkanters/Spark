import React from 'react';
import {createStackNavigator} from '@react-navigation/stack';
import {NavigationContainer} from '@react-navigation/native';
import { createMaterialBottomTabNavigator } from '@react-navigation/material-bottom-tabs';
import {ImageBackground, View, Text, StyleSheet, Image} from 'react-native';

import Ionicons from 'react-native-vector-icons/Ionicons';
import ProfileScreen from '../screens/afterLogin/ProfileScreen';
import MatchScreen from '../screens/afterLogin/MatchScreen';
import GameScreen from '../screens/afterLogin/GameScreen';
import ChatScreen from '../screens/afterLogin/ChatScreen';
import { Avatar} from 'react-native-paper';
import MaterialCommunityIcons from 'react-native-vector-icons/MaterialCommunityIcons';

const TabStack = props => {
  const Tab = createMaterialBottomTabNavigator();
  return (
  
    <Tab.Navigator
    activeColor="#ffd500"
    barStyle={{ backgroundColor: 'white' }}
      screenOptions={({route}) => ({
        tabBarIcon: ({focused, color, size}) => {
          let iconName;
          if (route.name === 'tab') {
            iconName = focused
              ? 'ios-information-circle'
              : 'ios-information-circle-outline';
          }
        },
        tabBarActiveTintColor: '#ffd500',
        tabBarInactiveTintColor: 'gray',
      })}>
      <Tab.Screen
        name="Profile"
        component={ProfileScreen}
        
        options={{
          headerShown: false,
          tabBarLabel: 'Home',
          tabBarIcon: ({ color }) => (
            <ImageBackground path color={color} size={26} />
          ),}}
        
      />

      <Tab.Screen
        name="Match"
        component={MatchScreen}
        options={{tabBarBadge: 3, headerShown: false}}
      />
      <Tab.Screen
        name="Game"
        component={GameScreen}
        options={{tabBarBadge: 3, headerShown: false}}
      />
      <Tab.Screen
        name="Chat"
        component={ChatScreen}
        options={{tabBarBadge: 3, headerShown: false}}
      />
    </Tab.Navigator>
    
  );
};
export default TabStack;

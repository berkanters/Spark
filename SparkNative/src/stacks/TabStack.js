import React from 'react';
import {createStackNavigator} from '@react-navigation/stack';
import {NavigationContainer} from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Ionicons from 'react-native-vector-icons/Ionicons';
import ProfileScreen from '../screens/afterLogin/ProfileScreen';
import MatchScreen from '../screens/afterLogin/MatchScreen';
import GameScreen from '../screens/afterLogin/GameScreen';
import ChatScreen from '../screens/afterLogin/ChatScreen';

const TabStack = props => {
  const Tab = createBottomTabNavigator();
  return (
    
    <NavigationContainer>
      <Tab.Navigator
        screenOptions={({ route }) => ({
          tabBarIcon: ({ focused, color, size }) => {
            let iconName;
            if (route.name === 'tab') {
              iconName = focused
                ? 'ios-information-circle'
                : 'ios-information-circle-outline';
            } 
            return <Ionicons name={iconName} size={size} color={color} />;
          },
          tabBarActiveTintColor: 'tomato',
          tabBarInactiveTintColor: 'gray',
        })}
      >
        <Tab.Screen name="Profile" component={ProfileScreen} />
        <Tab.Screen name="Match" component={MatchScreen} />
        <Tab.Screen name="Game" component={GameScreen} />
        <Tab.Screen name="Chat" component={ChatScreen} />
      </Tab.Navigator>    
    </NavigationContainer>
  );
};
export default TabStack;












import React from 'react';
import {createStackNavigator} from '@react-navigation/stack';
import {NavigationContainer} from '@react-navigation/native';
import LoginScreen from '../screens/LoginScreen';
import LandingScreen from '../screens/LandingScreen';
import RegisterScreen from '../screens/RegisterScreen';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Ionicons from 'react-native-vector-icons/Ionicons';
import tinder from '../screens/afterLogin/tinder'
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
        <Tab.Screen name="tinder" component={tinder} />
        <Tab.Screen name="tinder" component={tinder} />
      </Tab.Navigator>    
    </NavigationContainer>
  );
};
export default TabStack;












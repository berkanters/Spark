import React from 'react';
import {createStackNavigator} from '@react-navigation/stack';
import {NavigationContainer} from '@react-navigation/native';
import LoginScreen from '../screens/LoginScreen';
import LandingScreen from '../screens/LandingScreen';
import RegisterScreen from '../screens/RegisterScreen';
import TextingScreen from '../screens/outTabScreens/TextingScreen';
import ProfileEditScreen from '../screens/outTabScreens/ProfileEditScreen';
import ChatToProfileScreen from '../screens/outTabScreens/ChatToProfileScreen';
import TabStack from './TabStack';
const LandingStack = props => {
  const Stack = createStackNavigator();
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="LandingStack">
        <Stack.Screen
          name="Landing"
          component={LandingScreen}
          options={{headerShown: false}}
        />
        <Stack.Screen
          name="Login"
          component={LoginScreen}
          options={{headerShown: false}}
        />
        <Stack.Screen
          name="Register"
          component={RegisterScreen}
          options={{headerShown: false}}
        />
        <Stack.Screen
          name="Texting"
          component={TextingScreen}
          options={{headerShown: false}}
        />
        <Stack.Screen
          name="ProfileEdit"
          component={ProfileEditScreen}
          options={{headerShown: false}}
        />
        <Stack.Screen
          name="ChatToProfile"
          component={ChatToProfileScreen}
          options={{headerShown: false}}
        />

        <Stack.Screen
          name="tab"
          component={TabStack}
          options={{headerShown: false}}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
};
export default LandingStack;

import React from 'react';

import {Text, View, Image, ActivityIndicator} from 'react-native';

const SparkSplash = () => {
  return (
    <View style={styles.container}>
      <View style={{flex: 2, flexDirection: 'row', alignItems: 'center'}}>
        <Image
          source={require('../assets/yellow-lightning-png-images-928255.png')}
          style={{width: 200, height: 200}}
        />
        <Text style={styles.text}>Spark</Text>
      </View>
      <View style={{flex: 1, alignItems: 'center'}}>
        <ActivityIndicator size="large" color="#ffd500" />
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

  backgroundImage: {
    flex: 1,
    resizeMode: 'cover',
  },
};
export default SparkSplash;

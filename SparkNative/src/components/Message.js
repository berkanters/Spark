import React from 'react';
import styles from '../assets/Styles';

import {Text, View, Image} from 'react-native';

const Message = ({image, lastMessage, name, lastName}) => {
  return (
    <View style={styles.containerMessage}>
      <Image source={image} style={styles.avatar} />
      <View style={styles.content}>
        <Text>
          {name} {lastName}
        </Text>
        <Text style={styles.message}>{lastMessage}</Text>
      </View>
    </View>
  );
};

export default Message;

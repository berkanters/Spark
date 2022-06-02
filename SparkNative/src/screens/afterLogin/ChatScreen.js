import React from 'react'
import {Button, TextInput, Text} from 'react-native-paper';
import styles from '../../assets/Styles';
import {
  ScrollView,
  TouchableOpacity,
  ImageBackground,
  View,
  FlatList
} from 'react-native';
import Message from '../../components/Message';
import Icon from '../../components/Icon';
import Demo from '../../components/Demo';

const ChatScreen = () => {
  return (
    <ImageBackground
      source={require('../../assets/beyaz.jpg')}
      style={styles.bg}
    >
      <View style={styles.containerMessages}>
        <ScrollView>
          <View style={styles.top}>
            <Text style={styles.title}>Messages</Text>
            <TouchableOpacity>
              <Text style={styles.icon}>
                <Icon name="optionsV" />
              </Text>
            </TouchableOpacity>
          </View>

          <FlatList
            data={Demo}
            keyExtractor={(item, index) => index.toString()}
            renderItem={({ item }) => (
              <TouchableOpacity>
                <Message
                  image={item.image}
                  name={item.name}
                  lastMessage={item.message}
                />
              </TouchableOpacity>
            )}
          />
        </ScrollView>
      </View>
    </ImageBackground>
  );
};

export default ChatScreen;
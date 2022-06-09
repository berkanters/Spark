import React, {useState, useEffect, Component, useRef} from 'react';
import {
  ScrollView,
  TouchableOpacity,
  ImageBackground,
  View,
  TextInput,
  Image,
  StyleSheet,
  FlatList,
} from 'react-native';
import {Button, Text} from 'react-native-paper';
import AsyncStorage from '@react-native-async-storage/async-storage';
import axios from 'axios';
import ChatScreen from '../afterLogin/ChatScreen';

const TextingScreen = props => {
  const [user2id, setUser2id] = useState('');
  const [user2name, setUser2name] = useState('');
  const [user2lastName, setUser2lastName] = useState('');
  const [user, setUser] = useState('');
  const [messages, setMessages] = useState([]);
  const [itemStyle, setItemStyle] = useState('');
  const [isLoading, setLoading] = useState(true);
  const [text, setText] = useState('');
  const scrollViewRef = useRef();
  useEffect(() => {
    getData();
  }, []);

  useEffect(() => {
    getMessages();
  }, [user?.id]);
  console.log(text);
  const getData = async () => {
    try {
      console.log('getData');
      AsyncStorage.getItem('token').then(value => {
        if (value != null) {
          let veri = JSON.parse(value);
          setUser2id(props.route.params.itemId);
          setUser2name(props.route.params.itemName);
          setUser2lastName(props.route.params.itemLastName);
          setUser(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };

  const onClick = () => {
    console.log('onClick');
    axios
      .post('https://spark-api.conveyor.cloud/api/Chat', {
        user1id: user.id,
        user2id: user2id,
        messageText: text,
      })
      .then(function (response) {
        console.log('Message sent');
        getMessages();
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  const getMessages = () => {
    console.log('getMessages');
    axios
      .get(
        `https://spark-api.conveyor.cloud/messages=${user.id}&${user2id}`,
      )
      .then(function (response) {
        console.log('Messages fetched');
        setMessages(response.data);
        setText('');
        setLoading(false);
      })
      .catch(function (error) {
        console.log(error);
      });
  };
  console.log(messages);
  if (isLoading) {
    return <Text>Loading...</Text>;
  }
  return (
    <View style={styles.container}>
      <Text>Chat Screen With {user2name}</Text>
      <ScrollView
        style={styles.list}
        ref={scrollViewRef}
        onContentSizeChange={() =>
          scrollViewRef.current.scrollToEnd({animated: true})
        }>
        {messages.map(item => {
          if (user.id == item.user1Id)
            return (
              <View
                key={item.messageDate}
                style={[styles.item, styles.itemOut]}>
                <View style={[styles.balloon]}>
                  <Text>
                    {item.messageText}
                    {'     '}
                    <Text style={styles.time}>
                      {item.messageDate.substring(11, 16)}
                    </Text>
                  </Text>
                </View>
              </View>
            );
          return (
            <View key={item.messageDate} style={[styles.item, styles.itemIn]}>
              <View style={[styles.balloon]}>
                <Text>
                  {item.messageText}
                  {'     '}
                  <Text style={styles.time}>
                    {item.messageDate.substring(11, 16)}
                  </Text>
                </Text>
              </View>
            </View>
          );
        })}
      </ScrollView>
      <View style={styles.footer}>
        <View style={styles.inputContainer}>
          <TextInput
            value={text}
            style={styles.input}
            placeholder="Type a message"
            underlineColorAndroid="transparent"
            onChangeText={val => setText(val)}
          />
        </View>
        <TouchableOpacity onPress={onClick} style={styles.btnSend}>
          <Image
            source={{
              uri: 'https://img.icons8.com/small/75/ffffff/filled-sent.png',
            }}
            style={styles.iconSend}
          />
        </TouchableOpacity>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  list: {
    paddingHorizontal: 17,
  },
  footer: {
    flexDirection: 'row',
    height: 60,
    backgroundColor: '#eeeeee',
    paddingHorizontal: 10,
    padding: 5,
  },
  btnSend: {
    backgroundColor: '#ffd500',
    width: 40,
    height: 40,
    borderRadius: 360,
    alignItems: 'center',
    justifyContent: 'center',
  },
  iconSend: {
    width: 30,
    height: 30,
    alignSelf: 'center',
  },
  inputContainer: {
    borderBottomColor: '#F5FCFF',
    backgroundColor: '#FFFFFF',
    borderRadius: 30,
    borderBottomWidth: 1,
    height: 40,
    flexDirection: 'row',
    alignItems: 'center',
    flex: 1,
    marginRight: 10,
  },
  inputs: {
    height: 40,
    marginLeft: 16,
    borderBottomColor: '#FFFFFF',
    flex: 1,
  },
  balloon: {
    maxWidth: 250,
    padding: 15,
    borderRadius: 20,
  },
  itemIn: {
    alignSelf: 'flex-start',
    backgroundColor: '#A9ADAE',
  },
  itemOut: {
    alignSelf: 'flex-end',
    backgroundColor: '#ffd500',
  },
  time: {
    alignSelf: 'flex-end',
    margin: 15,
    fontSize: 12,
    color: '#ffffff',
  },
  item: {
    marginVertical: 14,
    flex: 1,
    flexDirection: 'row',
    backgroundColor: '#eeeeee',
    borderRadius: 300,
    padding: 5,
  },
});

export default TextingScreen;

// {
//   /* <ScrollView style={styles.list}>
//          {messages.map((item, index) => {
//           let itemStyle = styles.itemOut;
//           if (user.id == item.user1id) {
//             itemStyle = styles.itemIn;
//           }
//           <View style={[styles.item, itemStyle]}>
//             <View style={[styles.balloon]}>
//               <Text>{item.messageText}</Text>
//             </View>
//           </View>;
//         })}
//       </ScrollView>

// {(user.id != item.user1id ? (setItemStyle(styles.itemOut)) : (setItemStyle(styles.itemIn))
//   )}
// <View style={[styles.item, itemStyle]}>
//   <View style={[styles.balloon]}>
//     <Text>{item.messageText}</Text>
//   </View>
// </View>

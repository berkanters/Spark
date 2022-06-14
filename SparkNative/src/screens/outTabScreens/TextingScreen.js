import React, {useState, useEffect, Component, useRef} from 'react';
import {
  ScrollView,
  TouchableOpacity,
  ImageBackground,
  View,
  TextInput,
  Image,
  StyleSheet,
  Icon,
  FlatList,
} from 'react-native';
import {useNavigation} from '@react-navigation/native';
import {Button, Text} from 'react-native-paper';
import AsyncStorage from '@react-native-async-storage/async-storage';
import axios from 'axios';
import ChatScreen from '../afterLogin/ChatScreen';
import SparkSplash from '../../components/SparkSplash';
import styless from '../../assets/Styles';

const TextingScreen = props => {
  const navigation = useNavigation();
  const [user2id, setUser2id] = useState('');
  const [user2name, setUser2name] = useState('');
  const [user2lastName, setUser2lastName] = useState('');
  const [user, setUser] = useState('');
  const [messages, setMessages] = useState([]);
  const [itemStyle, setItemStyle] = useState('');
  const [isLoading, setLoading] = useState(true);
  const [text, setText] = useState('');
  const [user2ImagePath, setUser2ImagePath] = useState('');
  const scrollViewRef = useRef();
  const [profileImage, setProfileImage] = useState(defaultProfileImage);
  const defaultProfileImage = useState(
    'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAwBQTFRF7c5J78kt+/Xm78lQ6stH5LI36bQh6rcf7sQp671G89ZZ8c9V8c5U9+u27MhJ/Pjv9txf8uCx57c937Ay5L1n58Nb67si8tVZ5sA68tJX/Pfr7dF58tBG9d5e8+Gc6chN6LM+7spN1pos6rYs6L8+47hE7cNG6bQc9uFj7sMn4rc17cMx3atG8duj+O7B686H7cAl7cEm7sRM26cq/vz5/v767NFY7tJM78Yq8s8y3agt9dte6sVD/vz15bY59Nlb8txY9+y86LpA5LxL67pE7L5H05Ai2Z4m58Vz89RI7dKr+/XY8Ms68dx/6sZE7sRCzIEN0YwZ67wi6rk27L4k9NZB4rAz7L0j5rM66bMb682a5sJG6LEm3asy3q0w3q026sqC8cxJ6bYd685U5a457cIn7MBJ8tZW7c1I7c5K7cQ18Msu/v3678tQ3aMq7tNe6chu6rgg79VN8tNH8c0w57Q83akq7dBb9Nld9d5g6cdC8dyb675F/v327NB6////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/LvB3QAAAMFJREFUeNpiqIcAbz0ogwFKm7GgCjgyZMihCLCkc0nkIAnIMVRw2UhDBGp5fcurGOyLfbhVtJwLdJkY8oscZCsFPBk5spiNaoTC4hnqk801Qi2zLQyD2NlcWWP5GepN5TOtSxg1QwrV01itpECG2kaLy3AYiCWxcRozQWyp9pNMDWePDI4QgVpbx5eo7a+mHFOqAxUQVeRhdrLjdFFQggqo5tqVeSS456UEQgWE4/RBboxyC4AKCEI9Wu9lUl8PEGAAV7NY4hyx8voAAAAASUVORK5CYII=',
  );

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
          setUser2ImagePath(props.route.params.itemImagePath);
          setUser(veri);
        }
      });
    } catch (e) {
      // error reading value
    }
  };
  // const getUser2Photo = () => {
  //   axios
  //     .get(
  //       `https://spark-api-qv6.conveyor.cloud/getImage&Resources%5C%5CImages%5C%5C${user2id}.jpg`,
  //     )
  //     .then(function (response) {
  //       console.log(response.data);
  //       setProfileImage(response.data);
  //     })
  //     .catch(function (error) {
  //       console.log(error);
  //     });
  // };
  const onClick = () => {
    console.log('onClick');
    axios
      .post('https://spark-api-qv6.conveyor.cloud/api/Chat', {
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
  const openUser2Profile = () => {
    console.log('openUser2Profile');
    navigation.navigate('ChatToProfile', {
      user2id: user2id,
      user2ImagePath: user2ImagePath,
    });
  };
  const getMessages = () => {
    console.log('getMessages');
    axios
      .get(
        `https://spark-api-qv6.conveyor.cloud/messages=${user.id}&${user2id}`,
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
    return <SparkSplash />;
  }
  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <Text>
          <ImageBackground
            source={{uri: profileImage}}
            style={styless.miniPhoto}></ImageBackground>
          <TouchableOpacity onPress={openUser2Profile}>
            <Text
              style={{
                color: '#fff',
                fontFamily: '#46A575',
                paddingLeft: 25,
                paddingBottom: 15,
              }}>
              {user2name} {user2lastName}
            </Text>
          </TouchableOpacity>
        </Text>
      </View>

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
            style={styles.inputs}
            placeholder="Type a message"
            placeholderTextColor="#959696"
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
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 10,
    backgroundColor: '#ffd500',
    borderBottomWidth: 1,
    borderBottomColor: '#ddd',
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
    color: '#242424',
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

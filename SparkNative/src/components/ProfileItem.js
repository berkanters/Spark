import React from 'react';
import styles from '../assets/Styles';
import {Text, View, TouchableOpacity} from 'react-native';
import Icon from './Icon';
import {useNavigation} from '@react-navigation/native';
const ProfileItem = ({
  userId,
  age,
  info1,
  info2,
  info3,
  info4,
  location,
  matches,
  name,
  lastname,
  minage,
  maxage,
  range,
  gender,
}) => {
  const navigation = useNavigation();
  return (
    <View style={styles.containerProfileItem}>
      <View style={styles.matchesProfileItem}>
        <Text style={styles.matchesTextProfileItem}>{matches}</Text>
      </View>
      <TouchableOpacity
        style={{
          borderRadius: 25,
          backgroundColor: '#575656',
          width: 120,
          height: 25,
          paddingTop: 3,
          alignSelf: 'flex-end',
        }}
        onPress={() => navigation.navigate('ImageUpload', {userId: userId})}>
        <Text style={{color: '#ffd500'}}>{'  '}Upload an Image</Text>
      </TouchableOpacity>
      <Text style={styles.name}>
        {name} {lastname}
      </Text>

      <Text style={styles.descriptionProfileItem}>{age}</Text>

      <View style={styles.info}>
        <Text style={styles.iconProfile}>E-mail:</Text>
        <Text style={styles.infoContent}>{info1}</Text>
      </View>

      <View style={styles.info}>
        <Text style={styles.iconProfile}>Gender:</Text>
        <Text style={styles.infoContent}>{info2}</Text>
      </View>

      <View style={styles.info}>
        <Text style={styles.iconProfile}>Phone:</Text>
        <Text style={styles.infoContent}>{info3}</Text>
      </View>

      <View style={styles.info}>
        <Text style={styles.iconProfile}>Preferences:</Text>
        <Text style={styles.infoContent}>
          Min Age({minage}){'\n'}Max Age({maxage}){'\n'}Range ({range}){'\n'}
          Gender ({gender})
        </Text>
      </View>
    </View>
  );
};

export default ProfileItem;

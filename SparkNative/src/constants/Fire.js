import firebase from 'firebase';

class Fire{
    constructor(){
        this.init();
        this.checkAuth();
    }
    init = () => {
        if(!firebase.apps.length){
            firebase.initializeApp({
                apiKey: "AIzaSyD1xPqwFJklBMpiyP_GwZ0d1-ZLmNw8lrw",
                authDomain: "spark-9113e.firebaseapp.com",
                databaseURL: "https://spark-9113e-default-rtdb.europe-west1.firebasedatabase.app",
                projectId: "spark-9113e",
                storageBucket: "spark-9113e.appspot.com",
                messagingSenderId: "893547246005",
                appId: "1:893547246005:web:6f23b77d9896ec2a25e9fc",
                measurementId: "G-Z0LG0ZHG1S"
            });
    }
    };
    checkAuth = () => {
        firebase.auth().onAuthStateChanged(user => {
            if(user){
                this.userId = user.id;
                firebase.auth().singInAnonymously();
            }
            else{
                this.user = null;
                this.userId = null;
            }
        });
    };
    send = (messages) => {
        messages.foreach(item => {
            const message ={
                text: item.text,
                timestamp:firebase.database.ServerValue.TIMESTAMP,
                user:item.user
            }

            this.db.push(message);
        })
    }

    parse = (message) => {
        const {user, text, timestamp} = message.val();
        const {key: id} = message;
        const createdAt = new Date(timestamp);

        return{
            id,
            user,
            createdAt,
            text
        }
    }

    get = (callback) => {
        this.db.on('child_added', snapshot => callback(this.parse(snapshot)));
    }

    off(){
        this.db.off();
    }

    get db(){
        return firebase.database().ref('messages');
    }

    get uid(){
        return (firebase.auth().currentUser || {}).uid;
    }
}
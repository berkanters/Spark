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
            })
    }
}
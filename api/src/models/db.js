import mysql from 'mysql2'
import config from '../config.js'

class Db {
    connection;
    constructor() {
        this.connection = mysql.createConnection({
            host: config.host,
            user: config.username,
            password: config.password,
            database: config.database
        });
    }

    query(statement, parameters = []) {
        let p = new Promise((res, rej) => {

            this.connection.connect((err) => {

                if (err) {
                    rej(err);
                } 

                console.log("Connected!");

                this.connection.query(statement, parameters, (err2, result) => {
                    if (err2) {
                        rej(err2);
                    } else { 
                        res(result); 
                    }
                });

            });

        });

        return p;
    }

    end() {
        this.connection.end()
    }
}

export default Db
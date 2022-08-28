import Db from './db.js'

class TutorModel {
    static buscarTutorUsuarioSenha = async (login, senha) => {
        let db = new Db();
        try {
            var result = await db.query(
                'select * from usuarios where login = ? and senha = md5(?) and tipo  = ?', 
                [login, senha, 'TUTOR']
            );

            return result.length > 0 ? result[0] : null;
        } catch (error) {
            throw error;
        } finally {
            db.end();
        }
    }
}
export default TutorModel;
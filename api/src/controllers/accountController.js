import tutorModel from './../models/tutorModel.js'
class AccountController {

    static fazerLoginTutor = async (req, res) => {
        var user = await tutorModel.buscarTutorUsuarioSenha(req.body.login, req.body.senha);
        if (user == null) {
            res.status(400).json({
                erro: 'Usuário ou senha não encontrado'
            });
        } else {
            res.json({
                id: user.id,
                nome: user.nome
            });
        }
    }

}
export default AccountController
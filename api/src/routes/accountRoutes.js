import express from 'express'
import AccountController from '../controllers/accountController.js'

const router = express.Router();

router.post("/account/login-tutor", AccountController.fazerLoginTutor)

export default router;
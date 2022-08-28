import express from 'express'
import accountRoutes from './accountRoutes.js'

const routes = (app) => {
    app.route('/').get((req, res) => {
        res.send("Server listening")
    })

    app.use(
        //express.json(),
        accountRoutes
    )

}

export default routes
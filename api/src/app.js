import express from "express";
import routes from "./routes/index.js";
import bodyParser from 'body-parser'
import cors from 'cors'

const app = new express();

app.use(bodyParser.json())
app.use(cors())
routes(app);

export default app
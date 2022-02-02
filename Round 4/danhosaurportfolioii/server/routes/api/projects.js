const express = require('express');
const connect = require('mongodb');
const mongoConnectionString = `mongodb+srv://DanhosaurPortfolioIIApplication:database-admin@danhosaurportfolioii.x1ocs.mongodb.net/DanhosaurPortfolioIIDB?retryWrites=true&w=majority`;
const router = express.Router();

const log = (message) => console.log(`%c${new Date().toLocaleTimeString()} [API]: %c${message}`, "color: lime", "%cwhite");
async function getProjects() {
    const client = await connect(mongoConnectionString, {
        useNewUrlParser: true,
        useUnifiedTopology: true,
    });

    return client.db('DanhosaurPortfolioIIDB').collection('projects');
}

router.post('/', async (req, res) => {
    const projects = await getProjects();
    log('Creating project');
    await projects.insertOne({ ...JSON.parse(req.body.postData) });
    res.status(201).send();
});

router.get('/', async (req, res) => {
    log('Sending projects');
    const projects = await getProjects();
    res.send(await projects.find({}).toArray());
});
router.get('/:id', async (req, res) => {
    const projects = await getProjects();
    log('Sending project');
    const project = await projects.findOne({ _id: parseInt(req.params.id) });
    res.send(JSON.stringify(project))
})

router.put('/:id', async (req, res) => {
    const projects = await getProjects();
    log('Updating project');
    await projects.update({ _id: req.body._id }, req.body, { upsert: true });
    res.status(200).send();
});

router.delete('/:id', async (req, res) => {
    const projects = await getProjects();
    log('Deleting project');
    console.log(req.params)
    await projects.findOneAndDelete({ _id: Number.parseInt(req.params.id) })
    res.status(200).send();
});

module.exports = router;
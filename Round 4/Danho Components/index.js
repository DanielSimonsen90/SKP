const website = require('express')();

website.get('/', (req, res) => {
    res.send(`<h1>test</h1>`);
})

website.listen(3000, () => {
    console.log("Server's up\n\n");
});


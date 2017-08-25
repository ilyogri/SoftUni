const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.Types.ObjectId;

let articleSchema = mongoose.Schema({
    title: { type: String, require: true },
    content: { type: String, require: true },
    author: { type: ObjectId, require:true, ref: 'User' },
    date: { type: Date, default: Date.now() }
});

const Article = mongoose.model('Article', articleSchema);

module.exports = Article;
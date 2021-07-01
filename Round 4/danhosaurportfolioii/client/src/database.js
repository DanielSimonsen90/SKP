import mongoose, { connect } from 'mongoose';
import { Project } from 'models';

export const ProjectSchema = mongoose.model('ProjectSchema', new mongoose.Schema({
    _id: Number,
    name: String,
    description: String,
    language: String,
    projectType: String,
    createdAt: {
        year: Number,
        month: Number,
        day: Number,
    },
    link: String,
    image: String,
    display: Boolean,
    collab: {
        github: String,
        repo: String
    }
}));

const database = new class Database {
    /**
     * @param {(mongoose: typeof import('mongoose')) => Promise<T>} callback 
     */
    async execute(callback) {
        const m = connect(`mongodb+srv://DanhosaurPortfolioIIApplication:database-admin@danhosaurportfolioii.x1ocs.mongodb.net/DanhosaurPortfolioIIDB?retryWrites=true&w=majority`, {
            useNewUrlParser: true, 
        });
        return callback(m);
    }

    /**@param {Project} project*/
    create(project) {
        return this.execute(() => new ProjectSchema(project).save());
    }
    /**@returns {Project[]} */
    getAll() {
        return this.execute(async () => (await ProjectSchema.find({})).exec()).map(collectionDocument => collectionDocument.toObject());
    }
    /**
     * @param {Project} current 
     * @param {Project} updated 
     */
    update(current, updated) {
        return this.execute(() => ProjectSchema.updateOne({ _id: current._id }, updated, null, err => {
            if (err) throw err;
        }))
    }
    delete(project) {
        return this.execute(() => ProjectSchema.deleteOne({ _id: project._id }, null, err => {
            if (err) throw err;
        }))
    }
}();
export default database;
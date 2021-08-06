import { LocationCollection, ScheduleItem, Project, DanhoDate } from 'models'

export const contact = {
    github: "DanielSimonsen90",
    phone: "20 95 61 77",
    email: "DanielSimonsen90@gmail.com"
};
  
export const locationCollection = new LocationCollection(...[
    // new ScheduleItem("Folkeskole", new DanhoDate(2007, 8, 8), new DanhoDate(2017, 6, 15)),
    // new ScheduleItem("10. klasse", new DanhoDate(2017, 8, 8), new DanhoDate(2018, 6, 15)),
    new ScheduleItem("Grundforløb 1 & 2", new DanhoDate(2018, 8, 8), new DanhoDate(2019, 6, 28)),
    new ScheduleItem("Hovedforløb 1", new DanhoDate(2020, 1, 6), new DanhoDate(2020, 3, 13)),
    new ScheduleItem("Hovedforløb 2", new DanhoDate(2020, 8, 3), new DanhoDate(2020, 10, 9)),
    new ScheduleItem("Hovedforløb 3", new DanhoDate(2021, 4, 6), new DanhoDate(2021, 6, 18)),
    new ScheduleItem("Hovedforløb 4", new DanhoDate(2021, 10, 11), new DanhoDate(2021, 12, 17)),
    new ScheduleItem("Hovedforløb 5", new DanhoDate(2022, 9, 19), new DanhoDate(2022, 11, 25)),
    new ScheduleItem("Hovedforløb 6", new DanhoDate(2023, 11, 6), new DanhoDate(2023, 12, 8))
]).constructSKP();

import Home from './components/Home';
import About from './components/About';
import ProjectsIndex from './components/Projects';
import Plan from './components/Plan';
import Admin from './components/Admin';
import Images from './components/Admin/Image'
import NotFound from './components/Shared/NotFound';

/**@param {string[]} routes 
 * @param {any} component 
 * @param {any[]} children
 * @returns {{ path: string, component: any, children: { path: string, component: any }[] }[] }*/
 const makeRoutes = (routes, component, ...props) => 
 routes.map(route => {
   let result = { path: route, component };
   
   if (props.length) return { ...result, ...props.reduce((obj, i) => Object.assign(obj, ...props[i])) }
   return result;
 });

export const homeRoutes = makeRoutes(['', '/home', '/hjem'], Home);
export const aboutRoutes = makeRoutes(['/about', '/om'], About);
export const projectsRoutes = makeRoutes(['/projects', '/projekter'], ProjectsIndex)
export const planRoutes = makeRoutes(['/plan'], Plan);
export const adminRoutes = makeRoutes(['/admin'], Admin);
export const imagesRoutes = makeRoutes([...adminRoutes, ...projectsRoutes]
    .reduce((result, { path }) => { 
        result.push(`${path}/images`, `${path}/billeder`); 
        return result; 
    }, []), 
    Images
);
export const notFoundRoutes = makeRoutes(['*'], NotFound);

export const routes = [homeRoutes, aboutRoutes, projectsRoutes, planRoutes, adminRoutes, imagesRoutes, notFoundRoutes].reduce((result, route) => result.concat(...route));

import axios from 'axios';
// import { port } from '../../server/index';
const port = 8081;

export class API {
    static url = `http://localhost:${port}/api/projects`
    /**@param {Project} project*/
    static async createProject(project) {
        const data = {
            ...project,
            _id: (await this.getProjects()).length
        }
        await axios.post(API.url, { 
            postData: JSON.stringify(data)
        });
        const projectObj = await this.getProject(data._id);
        return projectObj;
    }
    /**@param {number} id @returns {Promise<Project>}*/
    static async getProject(id) {
        const response = await axios.get(`${API.url}/${id}`);
        const projectData = response.data;
        const { year, month, day } = projectData.createdAt;
        let project = new Project(projectData.name, {
            ...projectData,
            createdAt: new DanhoDate(year, month, day),
            image: projectData.image && Buffer.from(projectData.image)
        });
        project.link ?? (projectData.link != 'No link' && projectData.link);

        return project;
    }
    /**@returns {Promise<Project[]>}*/
    static async getProjects() {
        const response = await axios.get(API.url);
        return response.data.map(item => {
            const { year, month, day } = item.createdAt;
            let result = new Project(item.name, {
                ...item,
                createdAt: new DanhoDate(year, month, day),
                image: item.image && Buffer.from(item.image)
            });
            result.link = item.link;
            return result;
        });
    }
    static updateProject(updated) {
        return axios.put(`${API.url}/${updated._id}`, updated);
    }
    static deleteProject(project) {
        return axios.delete(`${API.url}/${project._id}`)
    }
}
export const projects = API.getProjects();

/**@param {Me} me*/
const getWhoDisContentDansk = (me) => [
    `Mit navn er ${me.name}, og jeg er en ${me.age} årig ung mand, som tager Datatekniker med speciale i programmerings uddannelsen på Techcollege, Aalborg.`,
    `Jeg har ${me.codingFor} års erfaring med programmering, og bruger rigtig meget af min fritid på forskellige projekter.`,
    `Objekt Orienteret Programmering har jeg stor glæde for, og bruger rigtig meget tid på at gøre min kode så fleksibelt som muligt via generics & callbacks.`,
    `Webudvikling, og generelt JavaScript/TypeScript, er alle noget jeg virkelig elsker at lege med. Det kan måske ses på hjemmesiden?`
];
/**@param {string} p*/
const whoDisSeeMyProjectDansk = (p) => `Se mit ${p} her`;

/**@param {Me} me*/
const getWhoDisContentEnglish = (me) => [
    `My name is ${me.name}, and I'm a ${me.age} year old young man, who's taking the "Datatechnician with speciality in Programming" education on Techcollege, Aalborg.`,
    `I've been coding for ${me.codingFor} years and use a ton og my sparetime on different projects.`,
    `Object Oriented Programming is something I really enjoy - I use a ton of my time on making my code as flexible as possible using generics & callbacks.`,
    `Webdevelopment, and generally JavaScript/TypeScript, are all something I really love to play with. It might be visible on the website?`
];
/**@param {string} p*/
const whoDisSeeMyProjectEnglish = (p) => `See my ${p} here`;

class DanhoMap extends Map {
    get(key) {
        return this.has(key) ? super.get(key) : key.substring(0, 1).toUpperCase() + key.substring(1);
    }
    /*** @param {'key' | 'value' | 'all'} filter */
    array(filter = 'all') {
        const result = [];
        for (const [key, value] of this) {
            result.push(filter == 'key' ? key : filter == 'value' ? value : [key, value]);
        }
        return result;
    }
    values() { return this.array('value'); }
    keys() { return this.array('key'); }
}

const Dansk = new DanhoMap([
    ['all', 'Alle'],
    ['baseLink', 'Base sti'],
    ['collab', 'Sammen med'],
    ['collabName', 'Partner'],
    ['collabRepo', 'Partner repo'],
    ['collabText', 'Projektet er lavet sammen med'],
    ['contact', 'Kontakt'],
    ['create', 'Opret'],
    ['createdAt', 'Oprettet'],
    ['delete', 'Slet'],
    ['description', 'Beskrivelse'],
    ['description-Dansk', 'Beskrivelse: Dansk'],
    ['description-English', 'Beskrivelse: Engelsk'],
    ['display', 'Vis'],
    ['end', 'Slut'],
    ['filterTitle', 'Projekt Filter'],
    ['hasLink', 'Er på Github'],
    ['image', 'Billede'],
    ['images', 'Billeder'],
    ['language', 'Sprog'],
    ['languagePlaceholder', 'Dette er en god beskrivelse til mit nye projekt.'],
    ['links', ['Hjem', 'Om', 'Projekter', 'Plan']],
    ['linkTexts', ['Se', 'på Github']],
    ['loadingProjects', 'Indlæser projekter.'],
    ['name', 'Navn'],
    ['noFile', 'Intet billede valgt'],
    ['noImage', 'Der er intet billede til'],
    ['noProjects', 'Der var ingen projekter til kriterierne.'],
    ['occupation', 'Beskæftigelse'],
    ['occupationStrings', ['I øjeblikket er jeg på', 'indtil']],
    ['phone', 'Telefon'],
    ['previousImage', 'Tidligere billede'],
    ['projects', 'Projekter'],
    ['project', 'Projekt'],
    ['projectImage', 'Projekt Billede'],
    ['projectInfo', 'Projekt Information'],
    ['projectNamePlaceholder', 'Mit super fede projekt'],
    ['projectOptional', 'Valgfrit'],
    ['projectType', 'Projekt Type'],
    ['spareTime', 'Fritid'],
    ['spareTimeDiscord', "Jeg bruger meget af min tid på Discord. Dette inkluderer min interesse for Discord bots, måden Discord er sat op på via components, og generelle permission handling."],
    ['spareTimeFLStudio', "Jeg tilbringer nogle gange min fritid på at lave min egen musik, som jeg sætter på services from Spotify & SoundCloud."],
    ['spareTimeOverwatch', "Som programmør er man naturligt interesseret i spil. Overwatch er det spil jeg spiller mest sammen med mine venner."],
    ['update', 'Opdatér'],
    ['uploadFile', 'Upload billede'],
    ['whoDisTitle', 'Hvem er jeg?'],
    ['whoDisContent', getWhoDisContentDansk],
    ['whoDisProjectString', 'Nogle af mine personlige ynglingsprojekter indgår:'],
    ['whoDisSeeMyProject', whoDisSeeMyProjectDansk],
]);
const English = new DanhoMap([
    ['baseLink', 'Base path'],
    ['collabInfo', 'Collab'],
    ['collabName', 'Collab'],
    ['collabRepo', 'Collab repo'],
    ['collabText', 'The project is made together with'],
    ['createdAt', 'Created at'],
    ['registerProject', 'Register project'],
    ['description-Dansk', 'Description: Danish'],
    ['description-English', 'Description: English'],
    ['filterTitle', 'Project Filter'],
    ['hasLink', 'Is on Github'],
    ['images', 'Images'],
    ['links', ['Home', 'About', 'Projects', 'Plan']],
    ['linkTexts', ['See', 'on Github']],
    ['loadingProjects', 'Loading projects.'],
    ['languagePlaceholder', 'This is a nice description for my new project.'],
    ['noFile', 'No image selected.'],
    ['noImage', 'There is no image for'],
    ['noProjects', 'There were no projecs for the criteria.'],
    ['occupationStrings', ["I'm current at", 'until']],
    ['previousImage', 'Previous image'],
    ['projectImage', 'Project Image'],
    ['projectInfo', 'Project Information'],
    ['projectNamePlaceholder', 'My super amazing project'],
    ['projectOptional', 'Optional'],
    ['projectType', 'Project Type'],
    ['spareTimeTitle', 'Sparetime'],
    ['spareTimeDiscord', "I use a lot of my time on Discord. This includes my interest for Discord bots, the way Discord is built using components and general permission handling."],
    ['spareTimeFLStudio', "I occationally use my time on making my own music, that I release on services such as Spotify & SoundCloud."],
    ['spareTimeOverwatch', "As a programmer, you're natrually interested in games. Overwatch is the game I play the most with my friends"],
    ['uploadFile', 'Upload File'],
    ['whoDisTitle', 'Who am I?'],
    ['whoDisContent', getWhoDisContentEnglish],
    ['whoDisProjectString', 'Some of my favorite projects include:'],
    ['whoDisSeeMyProject', whoDisSeeMyProjectEnglish],
]);

export const languages = new DanhoMap([
    ['Dansk', Dansk],
    ['English', English]
]);
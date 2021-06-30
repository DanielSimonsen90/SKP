import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'

Vue.config.productionTip = false
Vue.use(VueRouter);

import Home from './components/Home';
import About from './components/About';
import ProjectsIndex from './components/Projects';
import Projects from './components/Projects/Projects';
import Plan from './components/Plan';
import Admin from './components/Admin';
import NotFound from './components/Shared/NotFound';

/**@param {string[]} routes 
 * @param {any} component 
 * @param {any[]} children*/
const makeRoutes = (routes, component, ...props) => 
  routes.map(route => {
    let result = { path: route, component };
    
    if (props.length) return { ...result, ...props.reduce((obj, i) => Object.assign(obj, ...props[i])) }
    return result;
  });

const home = makeRoutes(['', '/home', '/hjem'], Home);
const about = makeRoutes(['/about', '/om'], About);

//domain.com/projects?language=C#&projectType=Library
//rounter.push({ name: 'projects' query: { language: 'C#', projectType: 'Library' } })
const projects = makeRoutes(['/projects', '/projekter'], ProjectsIndex, {
  children: makeRoutes([':filter'], Projects)
})
const plan = makeRoutes(['/plan'], Plan, {
  
});
const admin = makeRoutes(['/admin'], Admin);
const notFound = makeRoutes(['*'], NotFound);

const routes = [home, about, projects, plan, admin, notFound].reduce((result, route) => result.concat(...route));
const router = new VueRouter({ routes, mode: 'history' });
router.afterEach((to, from, next) => {
  const isProjects = (route) => projects.map(r => r.path).includes(route.fullPath.toLowerCase());

  //big fancy way to check if either {to} or {from} is /projects
  if ([to, from].map(r => isProjects(r)).filter(v => v).length)
    document.querySelector('#projects-filter')?.setAttribute('style', `visibility: ${isProjects(to) ? 'visible' : 'hidden'}`);
  return next;
});

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

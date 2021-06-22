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

const homes = [{
  path: '/home',
  component: Home
}, {
  path: '',
  component: Home
}];
const about = {
  path: '/about',
  component: About
};
const projects = {
  path: '/projects',
  component: ProjectsIndex,
  children: [
    //domain.com/projects?language=C#&projectType=Library
    //rounter.push({ name: 'projects' query: { language: 'C#', projectType: 'Library' } })
    { path: ':filter', component: Projects } 
  ]
};
const plan = {
  path: '/plan',
  component: Plan
};
const admin = {
  path: '/admin',
  component: Admin
}
const notFound = {
  path: '*',
  component: NotFound
};

const routes = [...homes, about, projects, plan, admin, notFound];
const router = new VueRouter({ routes, mode: 'history' })

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

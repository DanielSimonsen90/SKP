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

const home = [{
  path: '',
  component: Home
}, {
  path: '/home',
  component: Home
}, {
  path: '/hjem',
  component: Home
}];
const about = [{
  path: '/about',
  component: About
}, {
  path: '/om',
  component: About
}];

//domain.com/projects?language=C#&projectType=Library
//rounter.push({ name: 'projects' query: { language: 'C#', projectType: 'Library' } })
const projectChildren = [{
  path: ':filter', component: Projects
}]
const projects = [{
  path: '/projects',
  component: ProjectsIndex,
  children: projectChildren
}, {
  path: '/projekter',
  component: ProjectsIndex,
  children: projectChildren
}];
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

const routes = [...home, ...about, ...projects, plan, admin, notFound];
const router = new VueRouter({ routes, mode: 'history' })

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

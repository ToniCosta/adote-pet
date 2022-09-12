import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
	{
		path: '/',
		name: 'home',
		component: HomeView
	},
	{
		path: '/sobre',
		name: 'about',
		// route level code-splitting
		// this generates a separate chunk (about.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
	},
	{
		path: '/ajuda',
		name: 'help',
		// route level code-splitting
		// this generates a separate chunk (help.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "help" */ '../views/HelpView.vue')
	},
	{
		path: '/cadastro-pet',
		name: 'petRegistration',
		// route level code-splitting
		// this generates a separate chunk (petRegistration.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petRegistration" */ '../views/PetRegistrationView.vue')
	},
	{
		path: '/editar-pet/:id',
		name: 'petEdit',
		// route level code-splitting
		// this generates a separate chunk (petRegistration.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petRegistration" */ '../views/PetRegistrationView.vue')
	},
	{
		path: '/perfil-entidade',
		name: 'perfilEntidade',
		// route level code-splitting
		// this generates a separate chunk (petRegistration.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petRegistration" */ '../views/PerfilInstituicao.vue')
	},
	{
		path: '/pets-instituicao',
		name: 'petsInstituicao',
		// route level code-splitting
		// this generates a separate chunk (petsInstituicao.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petsInstituicao" */ '../views/PetsAdoptionEntidade.vue')
	},
	{
		path: '/pets-adocao',
		name: 'petsAdoption',
		// route level code-splitting
		// this generates a separate chunk (petsAdoption.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petsAdoption" */ '../views/PetsAdoption.vue')
	},
	{
		path: '/cadastro-tutor',
		name: 'tutorRegistration',
		// route level code-splitting
		// this generates a separate chunk (petsAdoption.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "tutorRegistration" */ '../views/TutorRegistrationView.vue')
	}
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes
})

export default router

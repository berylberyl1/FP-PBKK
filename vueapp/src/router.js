import { createRouter, createWebHistory } from 'vue-router';

const routes = [
    {
        path: '/',
        component: () => import('@/components/PageHome.vue')
    },
    {
        path: '/home',
        component: () => import('@/components/PageHome.vue')
    },
    {
        path: '/signup',
        component: () => import('@/components/PageSignUp.vue')
    },
    {
        path: '/login',
        component: () => import('@/components/PageLogIn.vue')
    },
    {
        path: '/book/:id',
        component: () => import('@/components/PageBookDetail.vue')
    },
    {
        path: '/cart',
        component: () => import('@/components/PageCart.vue')
    },
    {
        path: '/collection',
        component: () => import('@/components/PageCollection.vue')
    },
    {
        path: '/readtest',
        component: () => import('@/components/PageReadtest.vue')
    }

];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
import { createRouter, createWebHistory } from 'vue-router';

const routes = [
    {
        path: '/',
        component: () => import('@/components/PageHome.vue')
    },
    {
        path: '/signup',
        component: () => import('@/components/PageSignUp.vue')
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
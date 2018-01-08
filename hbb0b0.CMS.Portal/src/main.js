import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import App from './App.vue'
import VueRouter from 'vue-router'
import routerMap from './router.js'
// 引入axios以及element ui中的loading和message组件
import axios from 'axios';
import { Loading, Message } from 'element-ui'

Vue.use(VueRouter);
Vue.use(ElementUI);
Vue.prototype.$http = axios;
//axios.defaults.baseURL = "http://localhost:5001/api";
axios.defaults.baseURL = "http://localhost/CMS.API/api";

/**
 * http配置
 */
// 引入axios以及element ui中的loading和message组件

// 超时时间
axios.defaults.timeout = 5000
// http请求拦截器
var loadinginstace
axios.interceptors.request.use(config => {
  // element ui Loading方法
  loadinginstace = Loading.service({ fullscreen: true })
  return config
}, error => {
  loadinginstace.close()
  Message.error({
    message: '加载超时'
  })
  return Promise.reject(error)
})
// http响应拦截器
axios.interceptors.response.use(data => {// 响应成功关闭loading
  loadinginstace.close()
  return data
}, error => {
  loadinginstace.close()
  Message.error({
    message: '服务端发生错误'
  })
  return Promise.reject(error)
})

export default axios

const router = new VueRouter({ routes: routerMap })

const app = new Vue({
    router
}).$mount('#app');
<?php
// +----------------------------------------------------------------------
// | OneThink [ WE CAN DO IT JUST THINK IT ]
// +----------------------------------------------------------------------
// | Copyright (c) 2013 http://www.onethink.cn All rights reserved.
// +----------------------------------------------------------------------
// | Author: 麦当苗儿 <zuojiazi@vip.qq.com> <http://www.zjzit.cn>
// +----------------------------------------------------------------------

namespace Admin\Controller;
use User\Api\UserApi;

/**
 * 后台首页控制器
 * @author 麦当苗儿 <zuojiazi@vip.qq.com>
 */
class PublicController extends \Think\Controller {

    /**
     * 后台用户登录
     * @author 麦当苗儿 <zuojiazi@vip.qq.com>
     */
    public function login($username = null, $password = null, $verify = null){
        if(IS_POST){
            /* 检测验证码 TODO: */
            if (APP_DEBUG==false){
                if(!check_verify($verify)){
                    $this->error(L('_VERIFICATION_CODE_INPUT_ERROR_'));
                }
            }



            /* 调用UC登录接口登录 */
            $User = new UserApi;
            $uid = $User->login($username, $password);
            if(0 < $uid){ //UC登录成功
                /* 登录用户 */
                $Member = D('Member');
                if($Member->login($uid)){ //登录用户
                    //TODO:跳转到登录前页面
                    //$this->success(L('_LOGIN_SUCCESS_'), U('Index/index'));
                    //header('Location: http://www.baidu.com/');
                    //登录页面
                    $Session = session();
                    $data[status] = 1;
                    $data[url] = "http://localhost:8080/News/user?action=login&id=".$Session['user_auth']['uid']."&username=".$Session['user_auth']['username'];
                    $data[info] = "成功！";
                    $this->ajaxReturn($data, 'JSON');
                } else {
                    $data[status] = 0;
                    //$data[url] = "https://www.baidu.com?uid=".$Session['user_auth']['uid']."&user_name=".$Session['user_auth']['username'];
                    $data[info] = "失败！";
                    //$this->ajaxReturn($data, 'JSON');
                    $this->error($Member->getError());
                }

            } else { //登录失败
                switch($uid) {
                    case -1: $error = L('_USERS_DO_NOT_EXIST_OR_ARE_DISABLED_'); break; //系统级别禁用
                    case -2: $error = L('_PASSWORD_ERROR_'); break;
                    default: $error = L('_UNKNOWN_ERROR_'); break; // 0-接口参数错误（调试阶段使用）
                }
                $this->error($error);
            }
        } else {
            if(is_login()){
                //如果已经自动登录了、  到时候改成JSP的首页
                $this->redirect('Index/index');
            }else{
                /* 读取数据库中的配置 */
                $config	=	S('DB_CONFIG_DATA');
                if(!$config){
                    $config	=	D('Config')->lists();
                    S('DB_CONFIG_DATA',$config);
                }
                C($config); //添加配置

                $this->display();
            }
        }
    }

    /* 退出登录 */
    public function logout(){
        if(is_login()){
            D('Member')->logout();
            session('[destroy]');
            //http://localhost:8080/News/user?action=logout
            $this->success(L('_EXIT_SUCCESS_'), "http://localhost:8080/News/user?action=logout");
        } else {
            //到时候跳转到JSP
            $this->redirect('login');
        }
    }

    public function verify(){
        verify();
        // $verify = new \Think\Verify();
        // $verify->entry(1);
    }

}
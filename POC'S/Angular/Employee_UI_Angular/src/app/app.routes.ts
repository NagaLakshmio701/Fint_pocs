import { Routes } from '@angular/router';
import { MasterComponent } from './components/master/master.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { ClientComponent } from './components/client/client.component';
import { DesignationComponent } from './components/designation/designation.component';
import { LoginComponent } from './login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { authGuard } from './auth.guard';

export const routes: Routes = [

    {
        path:'',
        redirectTo:'login',     //default
        pathMatch:'prefix'
    },

    {
        path:'login',
        component:LoginComponent
    },
    {

        path:'',
        component:LayoutComponent,
        canActivate:[authGuard],

        children:[
            {
                path:'master',
                component:MasterComponent
            },
            {
                path:'employee',
                component:EmployeeComponent
            },
            {
                path:'client',
                component:ClientComponent,
            }
            ,
            {
                path:'designation',
                component:DesignationComponent
            }
        
        
        

        ]

    },
   
];

import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { AuthGuard } from './guards/auth.guard';
import { NgModule } from '@angular/core';
import { RegistroComponent } from './register/register.component';

const routes: Routes = [ 
{ path: '', redirectTo: 'login', pathMatch: 'full'}, 
{ path: 'login', component: LoginComponent}, 
{ path: 'registro', component: RegistroComponent}, 
{ path: 'admin',
  component: LayoutComponent,
  children: 
      [{
        path: '',
        loadChildren: () => import('./layout/layout.module').then(m => m.LayoutModule),
        canActivate:[AuthGuard]
      }]
},
{
  path: '**',
  redirectTo: 'login'
}];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes,{
       useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }

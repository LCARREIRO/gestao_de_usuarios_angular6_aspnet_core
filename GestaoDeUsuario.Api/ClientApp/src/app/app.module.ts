import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FilterPipeModule } from 'ngx-filter-pipe';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UsuarioCadastrarComponent } from './_usuario/cadastrar/usuario-cadastrar.component';
import { UsuarioEditarComponent } from './_usuario/editar/usuario-editar.component';
import { UsuarioListarComponent } from './_usuario/listar/usuario-listar.component';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UsuarioCadastrarComponent,
    UsuarioEditarComponent,
    UsuarioListarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    routing,
    HttpModule,
    FilterPipeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

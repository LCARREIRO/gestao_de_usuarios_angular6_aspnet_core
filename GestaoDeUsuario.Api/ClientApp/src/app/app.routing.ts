import { Routes, RouterModule } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UsuarioListarComponent } from './_usuario/listar/usuario-listar.component';
import { UsuarioCadastrarComponent } from './_usuario/cadastrar/usuario-cadastrar.component';
import { UsuarioEditarComponent } from './_usuario/editar/usuario-editar.component';

const routes: Routes = [

  { path: '', component: UsuarioCadastrarComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'listar', component: UsuarioListarComponent },
  { path: 'cadastrar', component: UsuarioCadastrarComponent },
  
];

export const routing = RouterModule.forRoot(routes);

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'employees',
    loadChildren: () =>
      import('./employees/employees.module').then(
        (module) => module.EmployeesModule
      ),
  },
  {
    path: 'employees/:id',
    loadChildren: () =>
      import('./employees/employees.module').then(
        (module) => module.EmployeesModule
      ),
  },
  {
    path: '**',
    redirectTo: 'employees',
  },
];

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule {}

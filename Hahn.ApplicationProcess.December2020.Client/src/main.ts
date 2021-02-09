import {Aurelia} from 'aurelia-framework';
import * as environment from '../config/environment.json';
import {PLATFORM} from 'aurelia-pal';

export function configure(aurelia: Aurelia): void {
  aurelia.use
    .standardConfiguration()
    .feature(PLATFORM.moduleName('resources/index'));

  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
    //.plugin(PLATFORM.moduleName('aurelia-dialog')); 
  }

  //aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}

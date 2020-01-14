export const environment = {
  production: false,
  hmr: true,
  application: {
    name: 'Organizations',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44309',
    clientId: 'Organizations_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'Organizations',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44347',
    },
  },
  localization: {
    defaultResourceName: 'Organizations',
  },
};
